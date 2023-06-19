namespace OpusMastery.Domain.Identity;

public class UserIdentifier
{
    public Guid? Id { get; private set; }

    private UserIdentifier(Guid? userId)
    {
        Id = userId;
    }

    public Guid GetUserIdOrThrow()
    {
        return Id ?? throw new InvalidOperationException($"UserId has not been set for the {nameof(UserIdentifier)}");
    }

    public static UserIdentifier Create(Guid? userId)
    {
        return new UserIdentifier(userId);
    }
}