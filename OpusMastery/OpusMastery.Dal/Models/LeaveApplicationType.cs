using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class LeaveApplicationType : EntityBase, INameableEntity
{
    public required string Name { get; set; }

    public ICollection<LeaveApplication> LeaveApplications { get; set; } = new List<LeaveApplication>();
}