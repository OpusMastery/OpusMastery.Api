using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class LeaveApplication : EntityBase, IAuditableEntity
{
    public DateTime? CreatedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }

    public required Guid EmployeeId { get; set; }
    public Employee Employee { get; set; } = null!;

    public required Guid TypeId { get; set; }
    public LeaveApplicationType Type { get; set; } = null!;

    public required Guid StatusId { get; set; }
    public LeaveApplicationStatus Status { get; set; } = null!;

    public required DateTime AppliedOn { get; set; }
    public required DateTime AppliedFromDate { get; set; }
    public required DateTime AppliedToDate { get; set; }
    public string? Reason { get; set; }
}