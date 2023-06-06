namespace OpusMastery.Admin.Controllers.V1.Leave.Dto;

public class LeaveFilterDto
{
    public bool ShowAppliedOnly { get; set; }
    public IEnumerable<string>? Types { get; set; }
    public ApplicationRange? ApplicationRange { get; set; }
}

public class ApplicationRange
{
    public DateTime? AppliedFrom { get; set; }
    public DateTime? AppliedTo { get; set; }
}