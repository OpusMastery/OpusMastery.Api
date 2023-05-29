using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models.Identity;

public class SystemUserEntityRight : EntityBase
{
    public required Guid RoleId { get; set; }
    public SystemUserRole Role { get; set; } = null!;

    public required string EntityName { get; set; }
    public required bool CanRead { get; set; }
    public required bool CanAdd { get; set; }
    public required bool CanModify { get; set; }
    public required bool CanDelete { get; set; }
}