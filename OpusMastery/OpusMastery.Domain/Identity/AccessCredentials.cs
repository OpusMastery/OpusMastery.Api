namespace OpusMastery.Domain.Identity;

public class AccessCredentials
{
    public string AccessToken { get; private set; }
    public string RefreshToken { get; private set; }
    public string TokenType { get; private set; }

    private AccessCredentials(string accessToken, string refreshToken, string tokenType)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        TokenType = tokenType;
    }

    public static AccessCredentials Create(string accessToken, string refreshToken, string tokenType)
    {
        return new AccessCredentials(accessToken, refreshToken, tokenType);
    }
}