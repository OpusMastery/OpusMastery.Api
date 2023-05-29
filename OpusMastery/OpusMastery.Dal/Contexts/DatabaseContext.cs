﻿using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Dal.Models;
using OpusMastery.Dal.Models.Abstractions;
using OpusMastery.Dal.Models.Identity;
using OpusMastery.Domain;
using OpusMastery.Domain.Identity;
using OpusMastery.Exceptions.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Dal.Contexts;

public class DatabaseContext : DbContext, IDatabaseContext
{
    private string ConnectionString { get; }

    public DbSet<SystemUser>? Users { get; set; }
    public DbSet<SystemUserRole>? UserRoles { get; set; }
    public DbSet<SystemUserEntityRight>? UserEntityRights { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<EmployeeRole>? EmployeeRoles { get; set; }
    public DbSet<Company>? Companies { get; set; }

    public DatabaseContext() : this(new ContextOptions { ConnectionString = "Host=;Port=;Database=;Username;Password;" }) { }

    public DatabaseContext(ContextOptions contextOptions)
    {
        ConnectionString = contextOptions.ConnectionString;
        SavingChanges += HandleSavingChangesEvent;
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

    private async void HandleSavingChangesEvent(object? sender, SavingChangesEventArgs @event)
    {
        await OnSavingChangesAsync();
    }

    private async Task OnSavingChangesAsync()
    {
        Guid? roleId = await GetCurrentUserRoleAsync();
        if (roleId is null)
        {
            return;
        }

        List<SystemUserEntityRight> userEntityRights = await Set<SystemUserEntityRight>()
            .AsNoTracking()
            .Where(entityRight => entityRight.RoleId == roleId)
            .ToListAsync();

        foreach (EntityEntry entityEntry in ChangeTracker.Entries())
        {
            if (!HasRequiredEntityRight(entityEntry, userEntityRights))
            {
                throw new InsufficientAccessRightsException(
                    $"The user with userId: {CurrentContextIdentity.User.Id} does not have access to the resource with the state {entityEntry.State}");
            }
        }
    }

    private async Task<Guid?> GetCurrentUserRoleAsync()
    {
        return (await Set<SystemUser>().AsNoTracking().FirstOrDefaultAsync(user => user.Id == CurrentContextIdentity.User.Id))?.RoleId;
    }

    private static bool HasRequiredEntityRight(EntityEntry entityEntry, IEnumerable<SystemUserEntityRight> userEntityRights)
    {
        return entityEntry.State switch
        {
            EntityState.Added => userEntityRights.Any(entityRight => entityRight.CanAdd && CheckEntityNameExistence(entityRight)),
            EntityState.Modified => userEntityRights.Any(entityRight => entityRight.CanModify && CheckEntityNameExistence(entityRight)),
            EntityState.Deleted => userEntityRights.Any(entityRight => entityRight.CanDelete && CheckEntityNameExistence(entityRight)),
            EntityState.Detached or EntityState.Unchanged => true,
            _ => throw new InvalidEnumArgumentException(nameof(entityEntry.State), entityEntry.State.ToInt32(), typeof(EntityState))
        };

        bool CheckEntityNameExistence(SystemUserEntityRight entityRight)
        {
            return entityRight.EntityName == entityEntry.Entity.GetType().Name || entityRight.EntityName is DomainConstants.EntityRight.FullAccess;
        }
    }
}