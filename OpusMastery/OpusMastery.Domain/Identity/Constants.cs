namespace OpusMastery.Domain.Identity;

public static class Constants
{
    public const string JwtAuthenticationType = "Bearer";
    public const string DefaultPassword = "ACc5894nGQAeiZdClrNZ";
    public const string FullAccessRight = "*";

    public static class Role
    {
        public static readonly Guid SupervisorRoleId = new("abb68e25-f550-4946-8b27-2be0d405c94c");
        public static readonly Guid AdministratorRoleId = new("e4ecd2dd-2762-4d32-b0b6-602e30f34844");
        public static readonly Guid ManagerRoleId = new("1c4ffcf7-1aed-49ee-b2f1-b0b2a3b8c5d6");
        public static readonly Guid DashboardUserRoleId = new("55a893fb-0bfa-49bc-b65c-cff598bb090e");
    }

    public static class ClaimName
    {
        public const string IdentityId = "IdentityId";
    }
}