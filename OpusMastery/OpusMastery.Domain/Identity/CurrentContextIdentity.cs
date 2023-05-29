namespace OpusMastery.Domain.Identity;

public static class CurrentContextIdentity
{
    private static readonly AsyncLocal<UserIdentifier?> UserIdentifier = new();

    public static UserIdentifier User
    {
        get => UserIdentifier.Value ?? throw new InvalidOperationException($"{nameof(Identity.UserIdentifier)} has not been set for the ${nameof(CurrentContextIdentity)}");
        private set => UserIdentifier.Value = value;
    }

    public static IDisposable SetIdentifier(UserIdentifier userIdentifier)
    {
        User = userIdentifier;
        return DisposableAction.Create(() => { UserIdentifier.Value = null; });
    }
}