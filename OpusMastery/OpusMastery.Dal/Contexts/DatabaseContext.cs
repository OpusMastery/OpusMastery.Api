using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Dal.Models;
using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Contexts;

public class DatabaseContext : DbContext, IDatabaseContext
{
    private string ConnectionString { get; }

    public DbSet<SystemUser>? Users { get; set; }
    public DbSet<SystemUserRole>? UserRoles { get; set; }
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
        entity.CreatedOn = DateTime.UtcNow;
        return base.AddAsync(entity, cancellationToken);
    }

    public async Task<int> SaveNewAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase
    {
        await AddAsync(entity, cancellationToken);
        return await SaveAsync(cancellationToken);
    }

    public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : EntityBase
    {
        foreach (TEntity entity in entities)
        {
            await AddAsync(entity, cancellationToken);
        }
    }

    public Task<int> SaveAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}