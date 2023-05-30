using OpusMastery.Extensions;

namespace OpusMastery.Domain.Identity;

public class UserRefreshToken
{
    public Guid UserId { get; private set; }
    public string Value { get; private set; }
    public DateTime ExpiresOn { get; private set; }

    private UserRefreshToken(Guid userId, string value, DateTime expiresOn)
    {
        UserId = userId;
        Value = value;
        ExpiresOn = expiresOn;
    }

    public static UserRefreshToken CreateNew(Guid userId, int tokenSize, DateTime expiresOn)
    {
        return new UserRefreshToken(userId, value: StringExtensions.GenerateRandomHexString(tokenSize), expiresOn);
    }

    public static UserRefreshToken Create(Guid userId, string value, DateTime expiresOn)
    {
        return new UserRefreshToken(userId, value, expiresOn);
    }
}