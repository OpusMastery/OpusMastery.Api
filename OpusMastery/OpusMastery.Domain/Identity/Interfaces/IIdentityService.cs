namespace OpusMastery.Domain.Identity.Interfaces;

public interface IIdentityService
{
    public Task<Guid> RegisterUserAsync(User user);
    public Task<AccessCredentials> LoginUserAsync(UserCredentials credentials);
    public Task<AccessCredentials> RefreshUserAccessTokenAsync(UserRefreshToken refreshToken);
}