namespace OpusMastery.Domain.Identity;

public class UserIdentifier
{
    public Guid? Id { get; private set; }

    private UserIdentifier(Guid? userId)
    {
        Id = userId;
    }

    public static UserIdentifier Create(Guid? userId)
    {
        return new UserIdentifier(userId);
    }
}