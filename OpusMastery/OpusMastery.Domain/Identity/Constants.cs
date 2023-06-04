namespace OpusMastery.Domain.Identity;

public static class Constants
{
    public const string JwtAuthenticationType = "Bearer";
    public const string DefaultPassword = "6a1af657cb6d6b081706a8d32b779f1b7212ef732403f382e84923242c63125e6890a87d8195794d21336a1de84ecbc9988cdcddb70bd7cc0b2980f4f766ecb1";
    public const string FullAccessRight = "*";

    public static class Role
    {
        public static readonly Guid DashboardUserRoleId = new("55a893fb-0bfa-49bc-b65c-cff598bb090e");
    }

    public static class ClaimName
    {
        public const string IdentityId = "IdentityId";
    }
}