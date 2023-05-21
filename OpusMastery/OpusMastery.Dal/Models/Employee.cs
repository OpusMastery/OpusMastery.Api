using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class Employee : EntityBase
{
    public Guid UserId { get; set; }
    public SystemUser User { get; set; } = null!;

    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public Guid RoleId { get; set; }
    public EmployeeRole Role { get; set; } = null!;
}