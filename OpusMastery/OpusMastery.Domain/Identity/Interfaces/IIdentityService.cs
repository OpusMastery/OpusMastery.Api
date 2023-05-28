namespace OpusMastery.Domain.Identity.Interfaces;

public interface IIdentityService
{
    public Task<Guid> RegisterUserAsync(DemoUser demoUser);
}