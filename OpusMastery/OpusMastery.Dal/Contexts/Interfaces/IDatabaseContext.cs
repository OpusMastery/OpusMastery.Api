using Microsoft.EntityFrameworkCore;
using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Contexts.Interfaces;

public interface IDatabaseContext
{
    public Task InitializeDatabaseAsync(CancellationToken cancellationToken = default);
    public DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;
}