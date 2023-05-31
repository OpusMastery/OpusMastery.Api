﻿using System.Security.Claims;
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
        user.SetRole(userRole);

        return await _identityRepository.SaveNewUserAsync(user);
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
        if (user is null || !user.ContainsGivenRefreshToken(refreshToken))
        {
            throw new RefreshTokenValidationException();
        }

        return await CreateAccessCredentialsAsync(user);
    }

    private async Task<AccessCredentials> CreateAccessCredentialsAsync(User user)
    {
        ClaimsIdentity claimsIdentity = _claimService.CreateIdentity(user);
        string newRefreshToken = await _claimService.GenerateNewRefreshTokenAsync(user);
        return _claimService.AuthenticateUser(claimsIdentity, newRefreshToken);
    }
}