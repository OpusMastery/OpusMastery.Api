namespace OpusMastery.Domain.Employee;

public static class EmployeeRoleManager
{
    private static readonly Dictionary<Guid, EmployeeRole> EmployeeRoles = new()
    {
        { Constants.WorkerRoleId, EmployeeRole.Worker },
        { Constants.HrManagerRoleId, EmployeeRole.HrManager },
        { Constants.CompanyOwnerRoleId, EmployeeRole.CompanyOwner }
    };

    public static Guid GetRoleIdByName(EmployeeRole role)
    {
        return EmployeeRoles.First(x => x.Value == role).Key;
    }
}

public enum EmployeeRole
{
    Worker = 1,
    HrManager,
    CompanyOwner
}