using OpusMastery.Dal.Models.Abstractions;
using OpusMastery.Dal.Models.Identity;

namespace OpusMastery.Dal.Models;

public class Company : EntityBase, IAuditableEntity, INameableEntity
{
    public DateTime? CreatedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }

    public required string Name { get; set; }
    public required string ContactEmail { get; set; }
    public required string ContactPhone { get; set; }

    public Guid? ManagerId { get; set; }
    public SystemUser? Manager { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}