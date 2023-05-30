namespace OpusMastery.Configuration;

public class JwtSettings
{
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required int AccessTokenExpiresInMinutes { get; set; }
    public required int RefreshTokenLength { get; set; }
    public required int RefreshTokenExpiresInMinutes { get; set; }
    public required string SecretKey { get; set; }

    public DateTime AccessTokenNotValidBefore => DateTime.UtcNow;
    public DateTime AccessTokenValidUntil => DateTime.UtcNow.AddMinutes(AccessTokenExpiresInMinutes);
    public DateTime RefreshTokenValidUntil => DateTime.UtcNow.AddMinutes(RefreshTokenExpiresInMinutes);
}