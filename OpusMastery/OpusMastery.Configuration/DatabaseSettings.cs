namespace OpusMastery.Configuration;

public class DatabaseSettings
{
    public string Host { get; set; }
    public string Port { get; set; }
    public string Database { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }

    public string ToConnectionString()
    {
        return $"{nameof(Host)}={Host};{nameof(Port)}={Port};{nameof(Database)}={Database};{nameof(Username)}={Username};{nameof(Password)}={Password};";
    }
}