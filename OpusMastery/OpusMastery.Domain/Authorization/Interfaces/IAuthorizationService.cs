namespace OpusMastery.Domain.Authorization.Interfaces;

public interface IAuthorizationService
{
    public Task<Guid> RegisterUserAsync(User user);
}