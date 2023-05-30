using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models.Identity;

public class SystemUserRole : EntityBase, INameableEntity
{
    public required string Name { get; set; }

    public ICollection<SystemUser> Users { get; set; } = new List<SystemUser>();
}