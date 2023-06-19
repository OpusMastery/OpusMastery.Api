namespace OpusMastery.Domain.Identity;

public static class UserRoleManager
{
    private static readonly Dictionary<Guid, UserRole> UserRoles = new()
    {
        { Constants.Role.SupervisorRoleId, UserRole.Supervisor },
        { Constants.Role.AdministratorRoleId, UserRole.Administrator },
        { Constants.Role.ManagerRoleId, UserRole.Manager },
        { Constants.Role.DashboardUserRoleId, UserRole.DashboardUser }
    };

    public static Guid GetRoleIdByName(UserRole role)
    {
        return UserRoles.First(x => x.Value == role).Key;
    }
}

public enum UserRole
{
    Supervisor = 1,
    Administrator,
    Manager,
    DashboardUser
}