namespace OpusMastery.Domain.Identity;

public class UserCredentials
{
    public string Email { get; private set; }
    public string Password { get; private set; }

    private UserCredentials(string email, string password)
    {
        Email = email;
        Password = password;
    }

    public static UserCredentials Create(string email, string password)
    {
        return new UserCredentials(email, password);
    }
}