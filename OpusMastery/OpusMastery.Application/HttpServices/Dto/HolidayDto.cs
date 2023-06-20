namespace OpusMastery.Application.HttpServices.Dto;

public class HolidayDto
{
    public required string GlobalName { get; set; }
    public required string LocalName { get; set; }
    public required DateOnly Date { get; set; }
}