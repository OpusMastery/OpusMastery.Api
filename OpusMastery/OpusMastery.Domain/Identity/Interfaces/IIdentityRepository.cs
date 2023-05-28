namespace OpusMastery.Domain.Identity.Interfaces;

public interface IIdentityRepository
{
    public Task<bool> IsUserExistsByEmailAsync(string email);
    public Task<Guid> SaveNewUserAsync(DemoUser demoUser);
}