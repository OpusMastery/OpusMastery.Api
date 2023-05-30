namespace OpusMastery.Domain.Identity.Interfaces;

public interface IIdentityService
{
    public Task<Guid> RegisterUserAsync(User user);
    public Task<JsonWebToken> LoginUserAsync(UserCredentials credentials);
    public Task RefreshUserAuthorizationAsync();
}