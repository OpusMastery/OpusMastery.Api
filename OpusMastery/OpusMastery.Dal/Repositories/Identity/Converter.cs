using OpusMastery.Dal.Models.Identity;
using OpusMastery.Domain.Identity;
using OpusMastery.Extensions;

namespace OpusMastery.Dal.Repositories.Identity;

public static class Converter
{
    public static SystemUser ToDal(this DemoUser demoUser)
    {
        return new SystemUser
        {
            Email = demoUser.Email,
            Password = demoUser.Password.ToSha512(),
            FirstName = demoUser.FirstName,
            LastName = demoUser.LastName,
            Status = demoUser.Status.ToEnumName(),
            RoleId = demoUser.RoleId
        };
    }
}