using OpusMastery.Dal.Models.Identity;
using OpusMastery.Domain.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Dal.Repositories.Identity;

public static class Converter
{
    public static User ToDomain(this SystemUser user)
    {
        return User.Create(
            user.Id,
            user.Email,
            user.Password,
            user.FirstName,
            user.LastName,
            user.Role.Name.ToEnum<UserRole>(),
            user.Status.ToEnum<UserStatus>(),
            user.RefreshToken?.ToDomain());
    }

    private static UserRefreshToken ToDomain(this SystemUserRefreshToken userRefreshToken)
    {
        return UserRefreshToken.Create(userRefreshToken.UserId, userRefreshToken.Value, userRefreshToken.ExpiresOn);
    }

    public static SystemUser ToDal(this User user)
    {
        return new SystemUser
        {
            Id = user.Id,
            Email = user.Email,
            Password = user.Password.ToSha512(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Status = user.Status.ToEnumName(),
            RoleId = UserRoleManager.GetRoleIdByName(user.Role)
        };
    }

    public static SystemUserRefreshToken ToDal(this UserRefreshToken refreshToken)
    {
        return new SystemUserRefreshToken
        {
            UserId = refreshToken.UserId,
            Value = refreshToken.Value,
            ExpiresOn = refreshToken.ExpiresOn
        };
    }
}