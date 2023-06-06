namespace OpusMastery.Admin.Controllers.V1.Leave.Dto;

public class LeaveCreationDto
{
    public required string Type { get; set; }
    public required DateTime AppliedFrom { get; set; }
    public required DateTime AppliedTo { get; set; }
    public string? Reason { get; set; }
}