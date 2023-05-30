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

    public async Task<bool> IsUserExistsByEmailAsync(string email)
    {
        return await GetUserBaseQuery().FirstOrDefaultAsync(user => user.Email == email) is not null;
    }

    public async Task<UserRole> GetDashboardUserRoleAsync()
    {
        var dashboardUserRole = await _databaseContext.Set<SystemUserRole>()
            .AsNoTracking()
            .FirstAsync(role => role.Id == DomainConstants.UserRole.DashboardUser);

        return dashboardUserRole.ToDomain();
    }

    public async Task<User?> GetUserByCredentialsAsync(UserCredentials credentials)
    {
        var systemUser = await GetUserBaseQuery().FirstOrDefaultAsync(user => user.Email == credentials.Email && user.Password == credentials.Password.ToSha512());
        return systemUser?.ToDomain();
    }

    public async Task<string> UpdateUserRefreshTokensAsync(User user)
    {
        await RemoveAllRefreshTokens(user.Id);
        return await SetNewRefreshTokenAsync(user);
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

    private Task RemoveAllRefreshTokens(Guid userId)
    {
        return _databaseContext.Set<SystemUserRefreshToken>().Where(refreshToken => refreshToken.UserId == userId).ExecuteDeleteAsync();
    }

    private async Task<string> SetNewRefreshTokenAsync(User user)
    {
        var systemUser = await _databaseContext.Set<SystemUser>().FirstAsync(systemUser => systemUser.Id == user.Id);
        var userRefreshToken = user.RefreshToken!.ToDal();

        systemUser.RefreshTokenId = userRefreshToken.Id;
        systemUser.RefreshToken = userRefreshToken;

        await _databaseContext.SaveUpdatedAsync(systemUser);
        return systemUser.RefreshToken.Value;
    }
}