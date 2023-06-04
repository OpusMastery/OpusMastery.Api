using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Dal.Models;
using OpusMastery.Dal.Models.Abstractions;
using OpusMastery.Dal.Models.Identity;
using OpusMastery.Domain.Identity;
using OpusMastery.Exceptions.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Dal.Contexts;

public class DatabaseContext : DbContext, IDatabaseContext
{
    private string ConnectionString { get; }

    public DbSet<SystemUser>? Users { get; set; }
    public DbSet<SystemUserRole>? UserRoles { get; set; }
    public DbSet<SystemUserRoleEntityRights>? UserRoleEntityRights { get; set; }
    public DbSet<SystemUserRefreshToken>? UserRefreshTokens { get; set; }
    public DbSet<SystemUserVerificationCode>? UserVerificationCodes { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<EmployeeRole>? EmployeeRoles { get; set; }
    public DbSet<Company>? Companies { get; set; }

    public DatabaseContext() : this(new ContextOptions { ConnectionString = "Host=;Port=;Database=;Username;Password;" }) { }

    public DatabaseContext(ContextOptions contextOptions)
    {
        ConnectionString = contextOptions.ConnectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConnectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SystemUser>().HasIndex(user => user.Email).IsUnique();

        modelBuilder.Entity<SystemUser>()
            .HasOne<SystemUserRefreshToken>(systemUser => systemUser.RefreshToken)
            .WithOne(refreshToken => refreshToken.User)
            .HasForeignKey<SystemUser>(systemUser => systemUser.RefreshTokenId);
    }

    public Task InitializeDatabaseAsync(CancellationToken cancellationToken = default)
    {
        return Database.MigrateAsync(cancellationToken);
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
    {
        return base.Set<TEntity>();
    }

    public new ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase
    {
        return base.AddAsync(entity, cancellationToken);
    }

    public async Task SaveNewAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase
    {
        await AddAsync(entity, cancellationToken);
        await SaveAsync(cancellationToken);
    }

    public Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : EntityBase
    {
        return base.AddRangeAsync(entities, cancellationToken);
    }

    public new EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : EntityBase
    {
        return base.Update(entity);
    }

    public Task SaveUpdatedAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase
    {
        base.Update(entity);
        return SaveAsync(cancellationToken);
    }

    public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase
    {
        base.RemoveRange(entities);
    }

    public Task SaveRemovedAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : EntityBase
    {
        base.RemoveRange(entities);
        return SaveAsync(cancellationToken);
    }

    public async Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        await HandleSavingChangesAsync(CurrentContextIdentity.User.Id);
        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task HandleSavingChangesAsync(Guid? userId)
    {
        var systemUser = await Set<SystemUser>().AsNoTracking().FirstOrDefaultAsync(user => user.Id == userId);

        if (systemUser?.RoleId is null)
        {
            return;
        }

        List<SystemUserRoleEntityRights> entityRights = await Set<SystemUserRoleEntityRights>()
            .AsNoTracking()
            .Where(entityRight => entityRight.RoleId == systemUser.RoleId)
            .ToListAsync();

        foreach (EntityEntry entityEntry in ChangeTracker.Entries())
        {
            if (!HasRequiredEntityRight(entityEntry, entityRights))
            {
                throw new InsufficientAccessRightsException($"The user with userId: {userId} does not have access to the resource with the state {entityEntry.State}.");
            }
        }
    }

    private static bool HasRequiredEntityRight(EntityEntry entityEntry, IEnumerable<SystemUserRoleEntityRights> entityRights)
    {
        return entityEntry.State switch
        {
            EntityState.Added => entityRights.Any(entityRight => entityRight.CanAdd && CheckEntityNameExistence(entityRight)),
            EntityState.Modified => entityRights.Any(entityRight => entityRight.CanModify && CheckEntityNameExistence(entityRight)),
            EntityState.Deleted => entityRights.Any(entityRight => entityRight.CanDelete && CheckEntityNameExistence(entityRight)),
            EntityState.Detached or EntityState.Unchanged => true,
            _ => throw new InvalidEnumArgumentException(nameof(entityEntry.State), entityEntry.State.ToInt32(), typeof(EntityState))
        };

        bool CheckEntityNameExistence(SystemUserRoleEntityRights entityRight)
        {
            return entityRight.Name == entityEntry.Entity.GetType().Name || entityRight.Name is Constants.FullAccessRight;
        }
    }
}