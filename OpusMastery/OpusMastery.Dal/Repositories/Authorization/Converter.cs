using OpusMastery.Dal.Models;
using OpusMastery.Domain.Authorization;
using OpusMastery.Extensions;

namespace OpusMastery.Dal.Repositories.Authorization;

public static class Converter
{
    public static SystemUser ToDal(this User user)
    {
        return new SystemUser
        {
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Status = user.Status.ToEnumName()
        };
    }
}