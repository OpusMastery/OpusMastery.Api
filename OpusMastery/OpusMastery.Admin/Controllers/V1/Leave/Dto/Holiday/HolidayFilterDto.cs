namespace OpusMastery.Admin.Controllers.V1.Leave.Dto.Holiday;

public class HolidayFilterDto
{
    public required string Timezone { get; set; }
    public DateTime StartingDate { get; set; } = DateTime.UtcNow;
    public DateTime EndingDate { get; set; } = DateTime.UtcNow.AddMonths(6);
}