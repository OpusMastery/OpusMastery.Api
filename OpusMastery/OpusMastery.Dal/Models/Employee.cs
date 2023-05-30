using OpusMastery.Dal.Models.Abstractions;
using OpusMastery.Dal.Models.Identity;

namespace OpusMastery.Dal.Models;

public class Employee : EntityBase, IAuditableEntity
{
    public DateTime? CreatedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }

    public required Guid UserId { get; set; }
    public SystemUser User { get; set; } = null!;

    public required Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public required Guid RoleId { get; set; }
    public EmployeeRole Role { get; set; } = null!;
}