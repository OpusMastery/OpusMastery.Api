using System.Security.Claims;
using OpusMastery.Domain.Email.Interfaces;
using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;
using OpusMastery.Exceptions.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Application.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly IClaimService _claimService;
    private readonly IEmailSender _emailSender;
    private readonly IIdentityRepository _identityRepository;

    public IdentityService(IClaimService claimService, IEmailSender emailSender, IIdentityRepository identityRepository)
    {
        _claimService = claimService;
        _emailSender = emailSender;
        _identityRepository = identityRepository;
    }

    public async Task<UserStatus> GetUserStatusAsync(string email)
    {
        User? user = await _identityRepository.GetUserByEmailAsync(email);
        return user?.Status ?? UserStatus.Nonexistent;
    }

    public async Task<Guid> RegisterUserAsync(User user)
    {
        (await _identityRepository.GetUserByEmailAsync(user.Email)).ThrowIfNotNull(() => new UserAlreadyExistsException(user.Email));

        Guid createdUserId = await _identityRepository.SaveNewUserAsync(user);

        await _emailSender.SendAsync(user);

        return createdUserId;
    }

    public async Task<AccessCredentials> LoginUserAsync(UserCredentials credentials)
    {
        User? user = await _identityRepository.GetUserByCredentialsAsync(credentials);
        if (user is null || user.Status is UserStatus.Deactivated)
        {
            throw new AuthenticationException();
        }

        return await CreateAccessCredentialsAsync(user);
    }

    public async Task<AccessCredentials> RefreshUserAccessTokenAsync(UserRefreshToken refreshToken)
    {
        User? user = await _identityRepository.GetUserById(refreshToken.UserId);
        if (user is null || !user.IsValidRefreshToken(refreshToken))
        {
            throw new RefreshTokenValidationException();
        }

        return await CreateAccessCredentialsAsync(user);
    }

    private async Task<AccessCredentials> CreateAccessCredentialsAsync(User user)
    {
        ClaimsIdentity claimsIdentity = _claimService.CreateIdentity(user);
        string newRefreshToken = await _claimService.GenerateNewRefreshTokenAsync(user);
        return await _claimService.AuthorizeUserAsync(claimsIdentity, newRefreshToken);
    }
}