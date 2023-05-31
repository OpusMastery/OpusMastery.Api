namespace OpusMastery.Domain;

public static class DomainConstants
{
    public const string JwtAuthenticationType = "Bearer";

    public static class UserRole
    {
        public static readonly Guid DashboardUser = new("55a893fb-0bfa-49bc-b65c-cff598bb090e");
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