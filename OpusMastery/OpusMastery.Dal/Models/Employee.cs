using OpusMastery.Dal.Models.Abstractions;
using OpusMastery.Dal.Models.Identity;

namespace OpusMastery.Dal.Models;

public class Employee : EntityBase
{
    public required Guid UserId { get; set; }
    public SystemUser User { get; set; } = null!;

    public required Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public required Guid RoleId { get; set; }
    public EmployeeRole Role { get; set; } = null!;
}