using Microsoft.EntityFrameworkCore;
using OpusMastery.Dal.Contexts.Interfaces;
using OpusMastery.Dal.Models.Identity;
using OpusMastery.Domain;
using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;
using OpusMastery.Extensions;

namespace OpusMastery.Dal.Repositories.Identity;

public class IdentityRepository : IIdentityRepository
{
    private readonly IDatabaseContext _databaseContext;

    public IdentityRepository(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task<UserRole> GetDashboardUserRoleAsync()
    {
        var dashboardUserRole = await _databaseContext.Set<SystemUserRole>()
            .AsNoTracking()
            .FirstAsync(role => role.Id == DomainConstants.UserRole.DashboardUser);

        return dashboardUserRole.ToDomain();
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return (await GetUserBaseQuery().FirstOrDefaultAsync(user => user.Email == email))?.ToDomain();
    }

    public async Task<User?> GetUserById(Guid userId)
    {
        return (await GetUserBaseQuery().FirstOrDefaultAsync(user => user.Id == userId))?.ToDomain();
    }

    public async Task<User?> GetUserByCredentialsAsync(UserCredentials credentials)
    {
        var systemUser = await GetUserBaseQuery().FirstOrDefaultAsync(user => user.Email == credentials.Email && user.Password == credentials.Password.ToSha512());
        return systemUser?.ToDomain();
    }

    public async Task<string> UpdateUserRefreshTokensAsync(User user)
    {
        var systemUser = await _databaseContext.Set<SystemUser>().FirstAsync(systemUser => systemUser.Id == user.Id);
        await RemoveAllRefreshTokens(systemUser);
        return await SetNewRefreshTokenAsync(systemUser, user.RefreshToken!);
    }

    public async Task<Guid> SaveNewUserAsync(User user)
    {
        var systemUser = user.ToDal();
        await _databaseContext.SaveNewAsync(systemUser);
        return systemUser.Id;
    }

    private IQueryable<SystemUser> GetUserBaseQuery()
    {
        return _databaseContext.Set<SystemUser>()
            .AsNoTracking()
            .Include(x => x.Role)
            .Include(x => x.RefreshToken);
    }

    private async Task RemoveAllRefreshTokens(SystemUser user)
    {
        List<SystemUserRefreshToken> refreshTokens = await _databaseContext.Set<SystemUserRefreshToken>()
            .Where(refreshToken => refreshToken.UserId == user.Id)
            .ToListAsync();

        user.RefreshTokenId = null;
        await _databaseContext.SaveRemovedAsync(refreshTokens);
    }

    private async Task<string> SetNewRefreshTokenAsync(SystemUser user, UserRefreshToken refreshToken)
    {
        var userRefreshToken = refreshToken.ToDal();

        await _databaseContext.AddAsync(userRefreshToken);
        user.RefreshTokenId = userRefreshToken.Id;

        await _databaseContext.SaveUpdatedAsync(user);
        return refreshToken.Value;
    }
}