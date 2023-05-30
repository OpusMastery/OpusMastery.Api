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
            user.Status.ToEnum<UserStatus>(),
            user.Role.ToDomain(),
            user.RefreshToken?.ToDomain());
    }

    public static UserRole ToDomain(this SystemUserRole userRole)
    {
        return UserRole.Create(userRole.Id, userRole.Name);
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
            RoleId = user.Role!.Id
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