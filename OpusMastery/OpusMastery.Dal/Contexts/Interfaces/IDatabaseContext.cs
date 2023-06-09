﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Contexts.Interfaces;

public interface IDatabaseContext : IAsyncDisposable
{
    public Task InitializeDatabaseAsync(CancellationToken cancellationToken = default);
    public DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;
    public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase;
    public Task SaveNewAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase;
    public Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : EntityBase;
    public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : EntityBase;
    public Task SaveUpdatedAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : EntityBase;
    public void RemoveRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : EntityBase;
    public Task SaveRemovedAsync<TEntity>(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) where TEntity : EntityBase;
    public Task<int> SaveAsync(CancellationToken cancellationToken = default);
}