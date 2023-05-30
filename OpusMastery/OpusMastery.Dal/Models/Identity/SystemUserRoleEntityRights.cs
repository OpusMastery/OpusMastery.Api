using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models.Identity;

public class SystemUserRoleEntityRights : EntityBase, INameableEntity
{
    public required string Name { get; set; }

    public required Guid RoleId { get; set; }
    public SystemUserRole Role { get; set; } = null!;

    public required bool CanRead { get; set; }
    public required bool CanAdd { get; set; }
    public required bool CanModify { get; set; }
    public required bool CanDelete { get; set; }
}