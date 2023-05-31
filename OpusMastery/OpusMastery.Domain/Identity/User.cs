namespace OpusMastery.Domain.Identity;

public class User
{
    public Guid Id { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string FullName => $"{FirstName} {LastName}";
    public UserStatus Status { get; private set; }
    public UserRole? Role { get; private set; }
    public UserRefreshToken? RefreshToken { get; private set; }

    private User(Guid id, string email, string password, string firstName, string lastName, UserStatus status)
    {
        Id = id;
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        Status = status;
    }

    private User(Guid id, string email, string password, string firstName, string lastName, UserStatus status, UserRole role, UserRefreshToken? refreshToken)
        : this(id, email, password, firstName, lastName, status)
    {
        Role = role;
        RefreshToken = refreshToken;
    }

    public void SetRole(UserRole role)
    {
        Role = role;
    }

    public bool ContainsGivenRefreshToken(UserRefreshToken refreshToken)
    {
        return RefreshToken is not null && RefreshToken.Value == refreshToken.Value && RefreshToken.ExpiresOn > DateTime.UtcNow;
    }

    public void GenerateRefreshToken(int tokenSize, DateTime expiresOn)
    {
        RefreshToken = UserRefreshToken.CreateNew(Id, tokenSize, expiresOn);
    }

    public static User CreateNew(string email, string password, string firstName, string lastName)
    {
        return new User(Guid.NewGuid(), email, password, firstName, lastName, UserStatus.NewlyCreated);
    }

    public static User Create(Guid id, string email, string password, string firstName, string lastName, UserStatus status, UserRole role, UserRefreshToken? refreshToken)
    {
        return new User(id, email, password, firstName, lastName, status, role, refreshToken);
    }
}

public enum UserStatus
{
    NewlyCreated = 0,
    Incomplete,
    Activated,
    Deactivated
}