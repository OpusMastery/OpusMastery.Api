using System.Security.Claims;

namespace OpusMastery.Domain.Identity.Interfaces;

public interface IClaimService
{
    public ClaimsIdentity CreateIdentity(User user);
    public Task<string> GenerateNewRefreshTokenAsync(User user);
    public Task<AccessCredentials> AuthorizeUserAsync(ClaimsIdentity claimsIdentity, string refreshToken);
}