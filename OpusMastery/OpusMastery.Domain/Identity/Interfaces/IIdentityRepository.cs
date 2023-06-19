namespace OpusMastery.Domain.Identity.Interfaces;

public interface IIdentityRepository
{
    public Task<User?> GetUserByEmailAsync(string email);
    public Task<User?> GetUserById(Guid userId);
    public Task<User?> GetUserByCredentialsAsync(UserCredentials credentials);
    public Task<string> UpdateUserRefreshTokensAsync(User user);
    public Task<Guid> SaveNewUserAsync(User user);
}