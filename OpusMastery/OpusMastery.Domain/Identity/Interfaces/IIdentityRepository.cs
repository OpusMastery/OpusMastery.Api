namespace OpusMastery.Domain.Identity.Interfaces;

public interface IIdentityRepository
{
    public Task<bool> IsUserExistsByEmailAsync(string email);
    public Task<UserRole> GetDashboardUserRoleAsync();
    public Task<User?> GetUserByCredentialsAsync(UserCredentials credentials);
    public Task<string> UpdateUserRefreshTokenAsync(User user);
    public Task<Guid> SaveNewUserAsync(User user);
}