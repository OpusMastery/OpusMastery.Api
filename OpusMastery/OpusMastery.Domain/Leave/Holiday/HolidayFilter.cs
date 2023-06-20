namespace OpusMastery.Domain.Leave.Holiday;

public class HolidayFilter
{
    public string Timezone { get; private set; }
    public DateTime StartingDate { get; private set; }
    public DateTime EndingDate { get; private set; }

    private HolidayFilter(string timezone, DateTime startingDate, DateTime endingDate)
    {
        Timezone = timezone;
        StartingDate = startingDate;
        EndingDate = endingDate;
    }

    public static HolidayFilter Create(string timezone, DateTime startingDate, DateTime endingDate)
    {
        return new HolidayFilter(timezone, startingDate, endingDate);
    }
}