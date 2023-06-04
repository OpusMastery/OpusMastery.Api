namespace OpusMastery.Domain.Employee;

public class EmployeeDetails
{
    public Guid UserId { get; private set; }
    public Guid CompanyId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Position { get; private set; }
    public EmployeeStatus Status { get; private set; }
    public DateTime JoiningDate { get; private set; }
    public string? Phone { get; private set; }
    public string? DepartmentName { get; private set; }
    public EmployeeRole? Role { get; private set; }

    private EmployeeDetails(
        Guid userId,
        Guid companyId,
        string firstName,
        string lastName,
        string email,
        string position,
        EmployeeStatus status,
        DateTime joiningDate,
        EmployeeRole? role,
        string? phone,
        string? departmentName)
    {
        UserId = userId;
        CompanyId = companyId;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Position = position;
        Status = status;
        JoiningDate = joiningDate;
        Role = role;
        Phone = phone;
        DepartmentName = departmentName;
    }

    public void SetUserId(Guid userId)
    {
        UserId = userId;
    }

    public void SetRole(EmployeeRole role)
    {
        Role = role;
    }

    public static EmployeeDetails CreateNew(
        Guid companyId,
        string firstName,
        string lastName,
        string email,
        string position,
        DateTime joiningDate,
        string? phone,
        string? departmentName)
    {
        return new EmployeeDetails(Guid.Empty, companyId, firstName, lastName, email, position, EmployeeStatus.Unconfirmed, joiningDate, default, phone, departmentName);
    }

    public static EmployeeDetails Create(
        Guid userId,
        Guid companyId,
        string firstName,
        string lastName,
        string email,
        string position,
        EmployeeStatus status,
        DateTime joiningDate,
        EmployeeRole role,
        string? phone,
        string? departmentName)
    {
        return new EmployeeDetails(userId, companyId, firstName, lastName, email, position, status, joiningDate, role, phone, departmentName);
    }
}

public enum EmployeeStatus
{
    Active = 1,
    Unconfirmed,
    Suspended,
    Inactive
}