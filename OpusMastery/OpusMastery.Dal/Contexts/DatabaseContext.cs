using Microsoft.EntityFrameworkCore;
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

    public Task InitializeDatabaseAsync(CancellationToken cancellationToken = default)
    {
        return Database.MigrateAsync(cancellationToken);
    }

    public new DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
    {
        return base.Set<TEntity>();
    }
}