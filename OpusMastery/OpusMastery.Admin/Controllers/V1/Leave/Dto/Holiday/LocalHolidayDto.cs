namespace OpusMastery.Admin.Controllers.V1.Leave.Dto.Holiday;

public class LocalHolidayDto
{
    public required string GlobalName { get; set; }
    public required string LocalName { get; set; }
    public required DateOnly Date { get; set; }
}