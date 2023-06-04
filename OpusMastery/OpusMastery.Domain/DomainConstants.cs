namespace OpusMastery.Domain;

public static class DomainConstants
{
    public const string JwtAuthenticationType = "Bearer";
    public const string DefaultPassword = "6a1af657cb6d6b081706a8d32b779f1b7212ef732403f382e84923242c63125e6890a87d8195794d21336a1de84ecbc9988cdcddb70bd7cc0b2980f4f766ecb1";

    public static class UserRole
    {
        public static readonly Guid DashboardUser = new("55a893fb-0bfa-49bc-b65c-cff598bb090e");
    }

    public static class EmployeeRole
    {
        public static readonly Guid Worker = new("535f8158-200c-4b54-a881-75a75192e606");
    }

    public static class EntityRight
    {
        public const string FullAccess = "*";
    }

    public static class IdentityClaim
    {
        public const string IdentityId = "IdentityId";
    }
}