namespace OpusMastery.Configuration;

public class DatabaseSettings
{
    public required string Host { get; set; }
    public required int Port { get; set; }
    public required string Database { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }

    public string ToConnectionString()
    {
        return $"{nameof(Host)}={Host};{nameof(Port)}={Port};{nameof(Database)}={Database};{nameof(Username)}={Username};{nameof(Password)}={Password};";
    }
}