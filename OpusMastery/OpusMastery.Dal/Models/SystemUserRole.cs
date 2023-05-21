using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class SystemUserRole : LookupEntityBase
{
    public ICollection<SystemUser> Users { get; set; } = new List<SystemUser>();
}