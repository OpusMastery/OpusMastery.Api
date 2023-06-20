namespace OpusMastery.Domain.Leave.Holiday;

public class HolidayFilter
{
    public string Timezone { get; private set; }
    public DateOnly? EndingDate { get; private set; }

    private HolidayFilter(string timezone, DateOnly? endingDate)
    {
        Timezone = timezone;
        EndingDate = endingDate;
    }

    public static HolidayFilter Create(string timezone, DateOnly? endingDate)
    {
        return new HolidayFilter(timezone, endingDate);
    }
}