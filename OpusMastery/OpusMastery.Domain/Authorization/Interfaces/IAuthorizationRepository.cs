namespace OpusMastery.Domain.Authorization.Interfaces;

public interface IAuthorizationRepository
{
    public Task<bool> IsUserExistsByEmailAsync(string email);
    public Task<Guid> SaveNewUserAsync(User user);
}