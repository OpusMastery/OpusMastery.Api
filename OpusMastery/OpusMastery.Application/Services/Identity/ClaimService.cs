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

    public ClaimService(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
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

    public JsonWebToken AuthenticateUser(ClaimsIdentity claimsIdentity, string refreshToken)
    {
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claimsIdentity.Claims,
            notBefore: _jwtSettings.NotValidBefore,
            expires: _jwtSettings.ValidUntil,
            signingCredentials: GetJwtSignature(_jwtSettings.SecretKey));

        string encodedAccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        return JsonWebToken.Create(encodedAccessToken, refreshToken, DomainConstants.JsonWebTokenType);
    }

    private static SigningCredentials GetJwtSignature(string securityKey)
    {
        return new SigningCredentials(new SymmetricSecurityKey(securityKey.ToByteArray()), SecurityAlgorithms.HmacSha512);
    }
}