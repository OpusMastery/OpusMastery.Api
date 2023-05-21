namespace OpusMastery.Domain.Authorization;

public class User
{
    public string Email { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public UserStatus Status { get; private set; }

    private User(string email, string firstName, string lastName, UserStatus status)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Status = status;
    }

    public static User CreateNew(string email, string firstName, string lastName)
    {
        return new User(email, firstName, lastName, UserStatus.NewlyCreated);
    }
}