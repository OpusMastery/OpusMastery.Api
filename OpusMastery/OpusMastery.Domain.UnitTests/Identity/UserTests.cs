using OpusMastery.Domain.Identity;
using Xunit;

namespace OpusMastery.Domain.UnitTests.Identity;

public class UserTests
{
    private readonly User _defaultUser;

    public UserTests()
    {
        _defaultUser = User.CreateNew(string.Empty, string.Empty, string.Empty, string.Empty);
    }

    [Fact]
    public void IsValidRefreshToken_ValidUserRefreshToken_ReturnsTrue()
    {
        // Arrange
        const int refreshTokenSize = 64;
        DateTime refreshTokenExpiresOn = DateTime.UtcNow.AddDays(1);
        _defaultUser.GenerateRefreshToken(refreshTokenSize, refreshTokenExpiresOn);

        UserRefreshToken refreshToken = UserRefreshToken.CreateWithoutExpiration(_defaultUser.Id, _defaultUser.RefreshToken!.Value);

        // Act
        bool actual = _defaultUser.IsValidRefreshToken(refreshToken);

        // Assert
        Assert.True(actual);
    }

    [Fact]
    public void IsValidRefreshToken_UserRefreshTokenExpired_ReturnsFalse()
    {
        // Arrange
        const int refreshTokenSize = 64;
        DateTime refreshTokenExpiresOn = DateTime.UtcNow.AddDays(-1);
        _defaultUser.GenerateRefreshToken(refreshTokenSize, refreshTokenExpiresOn);

        UserRefreshToken refreshToken = UserRefreshToken.CreateWithoutExpiration(_defaultUser.Id, _defaultUser.RefreshToken!.Value);

        // Act
        bool actual = _defaultUser.IsValidRefreshToken(refreshToken);

        // Assert
        Assert.False(actual);
    }
}