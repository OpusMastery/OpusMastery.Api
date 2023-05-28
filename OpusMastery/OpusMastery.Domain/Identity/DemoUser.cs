namespace OpusMastery.Domain.Identity;

public class DemoUser
{
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserStatus Status { get; private set; }

    private DemoUser(string email, string password, string firstName, string lastName, UserStatus status)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Status = status;
    }

    public static DemoUser CreateNew(string email, string password, string firstName, string lastName)
    {
        return new DemoUser(email, password, firstName, lastName, UserStatus.NewlyCreated);
    }
}