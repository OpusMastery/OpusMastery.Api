using System.Security.Claims;
using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;
using OpusMastery.Exceptions.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Application.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly IClaimService _claimService;
    private readonly IIdentityRepository _identityRepository;

    public IdentityService(IClaimService claimService, IIdentityRepository identityRepository)
    {
        _claimService = claimService;
        _identityRepository = identityRepository;
    }

    public async Task<Guid> RegisterUserAsync(User user)
    {
        (await _identityRepository.IsUserExistsByEmailAsync(user.Email))
            .ThrowIfTrue(() => new UserAlreadyExistsException(user.Email));

        var userRole = await _identityRepository.GetDashboardUserRoleAsync();
        user.SetNewRole(userRole);

        return await _identityRepository.SaveNewUserAsync(user);
    }

    public async Task<JsonWebToken> LoginUserAsync(UserCredentials credentials)
    {
        User? user = await _identityRepository.GetUserByCredentialsAsync(credentials);
        if (user is null || user.Status is UserStatus.Deactivated)
        {
            throw new AuthenticationException();
        }

        ClaimsIdentity claimsIdentity = _claimService.CreateIdentity(user);
        string refreshToken = await _claimService.GenerateNewRefreshTokenAsync(user);
        return _claimService.AuthenticateUser(claimsIdentity, refreshToken);
    }

    public Task RefreshUserAuthorizationAsync()
    {
        return Task.CompletedTask;
    }
}