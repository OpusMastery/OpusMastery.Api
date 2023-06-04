using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpusMastery.Application.Extensions;
using OpusMastery.Configuration;
using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;

namespace OpusMastery.Application.Services.Identity;

public class ClaimService : IClaimService
{
    private readonly JwtSettings _jwtSettings;
    private readonly IIdentityRepository _identityRepository;

    public ClaimService(IOptions<ApplicationSettings> applicationSettings, IIdentityRepository identityRepository)
    {
        _jwtSettings = applicationSettings.Value.JwtSettings;
        _identityRepository = identityRepository;
    }

    public ClaimsIdentity CreateIdentity(User user)
    {
        IEnumerable<Claim> requiredClaims = new List<Claim>
        {
            new(ClaimTypes.Email, user.Email),
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.Role, user.Role!.Name),
            new(Constants.ClaimName.IdentityId, user.Id.ToString())
        };

        return new ClaimsIdentity(
            requiredClaims,
            Constants.JwtAuthenticationType,
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
    }

    public Task<string> GenerateNewRefreshTokenAsync(User user)
    {
        user.GenerateRefreshToken(_jwtSettings.RefreshTokenLength, _jwtSettings.RefreshTokenValidUntil);
        return _identityRepository.UpdateUserRefreshTokensAsync(user);
    }

    public AccessCredentials AuthenticateUser(ClaimsIdentity claimsIdentity, string refreshToken)
    {
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claimsIdentity.Claims,
            notBefore: _jwtSettings.AccessTokenNotValidBefore,
            expires: _jwtSettings.AccessTokenValidUntil,
            signingCredentials: new SigningCredentials(_jwtSettings.SecretKey.GetSecurityKey(), SecurityAlgorithms.HmacSha512));

        string encodedAccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return AccessCredentials.Create(encodedAccessToken, refreshToken, Constants.JwtAuthenticationType);
    }
}