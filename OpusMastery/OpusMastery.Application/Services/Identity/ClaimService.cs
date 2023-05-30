using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpusMastery.Configuration;
using OpusMastery.Domain;
using OpusMastery.Domain.Identity;
using OpusMastery.Domain.Identity.Interfaces;
using OpusMastery.Extensions;

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
            new(DomainConstants.IdentityClaim.IdentityId, user.Id.ToString())
        };

        return new ClaimsIdentity(
            requiredClaims,
            DefaultAuthenticationTypes.ExternalBearer,
            ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
    }

    public Task<string> GenerateNewRefreshTokenAsync(User user)
    {
        user.GenerateNewRefreshToken(_jwtSettings.RefreshTokenLength, _jwtSettings.RefreshTokenValidUntil);
        return _identityRepository.UpdateUserRefreshTokensAsync(user);
    }

    public JsonWebToken AuthenticateUser(ClaimsIdentity claimsIdentity, string refreshToken)
    {
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claimsIdentity.Claims,
            notBefore: _jwtSettings.AccessTokenNotValidBefore,
            expires: _jwtSettings.AccessTokenValidUntil,
            signingCredentials: GetJwtSignature(_jwtSettings.SecretKey));

        string encodedAccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return JsonWebToken.Create(encodedAccessToken, refreshToken, DomainConstants.JsonWebTokenType);
    }

    private static SigningCredentials GetJwtSignature(string securityKey)
    {
        return new SigningCredentials(new SymmetricSecurityKey(securityKey.ToByteArray()), SecurityAlgorithms.HmacSha512);
    }
}