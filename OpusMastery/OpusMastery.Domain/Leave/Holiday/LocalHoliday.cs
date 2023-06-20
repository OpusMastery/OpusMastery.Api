namespace OpusMastery.Domain.Leave.Holiday;

public class LocalHoliday
{
    public string GlobalName { get; private set; }
    public string LocalName { get; private set; }
    public DateOnly Date { get; private set; }

    private LocalHoliday(string globalName, string localName, DateOnly date)
    {
        GlobalName = globalName;
        LocalName = localName;
        Date = date;
    }

    public static LocalHoliday Create(string globalName, string localName, DateOnly date)
    {
        return new LocalHoliday(globalName, localName, date);
    }
}