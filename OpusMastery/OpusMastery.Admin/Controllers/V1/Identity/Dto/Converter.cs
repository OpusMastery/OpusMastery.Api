using OpusMastery.Domain.Identity;

namespace OpusMastery.Admin.Controllers.V1.Identity.Dto;

public static class Converter
{
    public static User ToDomain(this DemoUserRegistrationDto demoUserRegistrationDto)
    {
        return User.CreateNew(
            demoUserRegistrationDto.Email.ToLower(),
            demoUserRegistrationDto.Password,
            demoUserRegistrationDto.FirstName,
            demoUserRegistrationDto.LastName);
    }

    public static UserCredentials ToDomain(this LoginFormDto loginFormDto)
    {
        return UserCredentials.Create(loginFormDto.Email.ToLower(), loginFormDto.Password);
    }

    public static UserRefreshToken ToDomain(this RefreshAccessTokenDto refreshAccessTokenDto)
    {
        return UserRefreshToken.CreateWithoutExpiration(refreshAccessTokenDto.UserId, refreshAccessTokenDto.RefreshToken);
    }

    public static AccessCredentialsDto ToDto(this AccessCredentials accessCredentials)
    {
        return new AccessCredentialsDto
        {
            AccessToken = accessCredentials.AccessToken,
            RefreshToken = accessCredentials.RefreshToken,
            TokenType = accessCredentials.TokenType
        };
    }
}