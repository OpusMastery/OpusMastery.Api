using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class LeaveApplicationStatus : EntityBase, INameableEntity
{
    public required string Name { get; set; }
    public DateTime? ApprovedOn { get; set; }
    public Guid? ApprovedById { get; set; }

    public ICollection<LeaveApplication> LeaveApplications { get; set; } = new List<LeaveApplication>();
}