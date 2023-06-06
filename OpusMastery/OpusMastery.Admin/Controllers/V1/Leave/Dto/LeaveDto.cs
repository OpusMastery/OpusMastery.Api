namespace OpusMastery.Admin.Controllers.V1.Leave.Dto;

public class LeaveDto
{
    public required Guid EmployeeId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Type { get; set; }
    public required string Status { get; set; }
    public required DateTime AppliedFrom { get; set; }
    public required DateTime AppliedTo { get; set; }
    public required string? Reason { get; set; }
}