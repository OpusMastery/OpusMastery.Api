using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;
using OpusMastery.Exceptions.Identity;

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
        bool isExistingUser = await _identityRepository.IsUserExistsByEmailAsync(demoUser.Email);

        if (isExistingUser)
        {
            throw new UserAlreadyExistsException($"The user with email: {demoUser.Email} has already been registered");
        }

        return await _identityRepository.SaveNewUserAsync(demoUser);
    }
}