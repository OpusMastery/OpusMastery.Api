namespace OpusMastery.Domain.Identity;

public class UserIdentifier
{
    public Guid? Id { get; private set; }

    private UserIdentifier(Guid? id)
    {
        Id = id;
    }

    public static UserIdentifier Create(Guid? userId)
    {
        return new UserIdentifier(userId);
    }
}