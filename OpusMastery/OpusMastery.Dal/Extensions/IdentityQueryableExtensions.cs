namespace OpusMastery.Dal.Extensions;

public static class IdentityQueryableExtensions
{
    // public static async Task<TEntity> FirstWithIdentityRightsAsync<TEntity>(
    //     this IQueryable<TEntity> queryable,
    //     IDatabaseContext databaseContext,
    //     Expression<Func<TEntity, bool>> predicate,
    //     CancellationToken cancellationToken = default)
    // {
    //     Guid roleId = await databaseContext.GetUserRoleAsync(Guid.NewGuid());
    //     databaseContext.Set<SystemUserEntityRight>()
    //     return databaseContext.Set<SystemUserEntityRight>();
    // }
    //
    // public static async Task<IQueryable<TEntity>> ToListWithIdentityRightsAsync<TEntity>(
    //     this IQueryable<TEntity> queryable,
    //     IDatabaseContext databaseContext,
    //     CancellationToken cancellationToken = default)
    // {
    //     Guid roleId = await databaseContext.GetUserRoleAsync(Guid.NewGuid());
    //     return databaseContext.Set<SystemUserEntityRight>();
    // }
    //
    // private static async Task<Guid> GetUserRoleAsync(this IDatabaseContext databaseContext, Guid userId)
    // {
    //     return (await databaseContext.Set<SystemUser>()
    //             .AsNoTracking()
    //             .FirstOrDefaultAsync(user => user.Id == userId))
    //         .ThrowIfNull(() => new UserNotFoundException($"The user with userId: {userId} does not exist")).RoleId;
    // }
}