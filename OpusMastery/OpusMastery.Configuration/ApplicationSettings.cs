namespace OpusMastery.Configuration;

public class ApplicationSettings
{
    public const string Key = "Application";

    public DatabaseSettings DatabaseSettings { get; set; } = null!;
}