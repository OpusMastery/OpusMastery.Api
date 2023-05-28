using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;
using OpusMastery.Exceptions.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Application.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly IIdentityRepository _identityRepository;

    public IdentityService(IIdentityRepository identityRepository)
    {
        _identityRepository = identityRepository;
    }

    public async Task<Guid> RegisterUserAsync(DemoUser demoUser)
    {
        (await _identityRepository.IsUserExistsByEmailAsync(demoUser.Email))
            .ThrowIfTrue(() => new UserAlreadyExistsException($"The user with email: {demoUser.Email} has been already registered"));

        return await _identityRepository.SaveNewUserAsync(demoUser);
    }
}