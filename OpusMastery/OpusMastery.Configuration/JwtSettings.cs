﻿namespace OpusMastery.Configuration;

public class JwtSettings
{
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public required int ExpiresInMinutes { get; set; }
    public required string SecretKey { get; set; }
    public DateTime NotValidBefore => DateTime.UtcNow;
    public DateTime ValidUntil => DateTime.UtcNow.AddMinutes(ExpiresInMinutes);
}