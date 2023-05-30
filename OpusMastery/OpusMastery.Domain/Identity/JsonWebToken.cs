namespace OpusMastery.Domain.Identity;

public class JsonWebToken
{
    public string AccessToken { get; private set; }
    public string RefreshToken { get; private set; }
    public string TokenType { get; private set; }

    private JsonWebToken(string accessToken, string refreshToken, string tokenType)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
        TokenType = tokenType;
    }

    public static JsonWebToken Create(string accessToken, string refreshToken, string tokenType)
    {
        return new JsonWebToken(accessToken, refreshToken, tokenType);
    }
}