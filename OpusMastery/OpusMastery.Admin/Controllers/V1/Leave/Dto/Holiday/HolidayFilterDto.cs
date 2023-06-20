namespace OpusMastery.Admin.Controllers.V1.Leave.Dto.Holiday;

public class HolidayFilterDto
{
    public required string Timezone { get; set; }
    public DateOnly? EndingDate { get; set; }
}