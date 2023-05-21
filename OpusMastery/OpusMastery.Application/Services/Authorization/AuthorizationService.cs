using OpusMastery.Domain.Authorization;
using OpusMastery.Domain.Authorization.Interfaces;

namespace OpusMastery.Application.Services.Authorization;

public class AuthorizationService : IAuthorizationService
{
    private readonly IAuthorizationRepository _authorizationRepository;

    public AuthorizationService(IAuthorizationRepository authorizationRepository)
    {
        _authorizationRepository = authorizationRepository;
    }

    public async Task<Guid> RegisterUserAsync(User user)
    {
        bool isExistingUser = await _authorizationRepository.IsUserExistsByEmailAsync(user.Email);
        
        if (isExistingUser)
        {
            throw new ArgumentException($"The user with email: {user.Email} has already been registered");
        }
        
        return await _authorizationRepository.SaveNewUserAsync(user);
    }
}