namespace OpusMastery.Domain.Employee;

public class EmployeeDetails
{
    public Guid Id { get; private set; }
    public Guid CompanyId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Position { get; private set; }
    public EmployeeStatus Status { get; private set; }
    public DateOnly JoiningDate { get; private set; }
    public EmployeeRole Role { get; private set; }
    public string? Phone { get; private set; }
    public string? DepartmentName { get; private set; }

    private EmployeeDetails(
        Guid id,
        Guid companyId,
        string firstName,
        string lastName,
        string email,
        string position,
        EmployeeStatus status,
        DateOnly joiningDate,
        EmployeeRole role,
        string? phone,
        string? departmentName)
    {
        Id = id;
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

    public static EmployeeDetails CreateNew(
        Guid companyId,
        string firstName,
        string lastName,
        string email,
        string position,
        DateOnly joiningDate,
        EmployeeRole role,
        string? phone,
        string? departmentName)
    {
        return new EmployeeDetails(Guid.NewGuid(), companyId, firstName, lastName, email, position, EmployeeStatus.Unconfirmed, joiningDate, role, phone, departmentName);
    }

    public static EmployeeDetails Create(
        Guid id,
        Guid companyId,
        string firstName,
        string lastName,
        string email,
        string position,
        EmployeeStatus status,
        DateOnly joiningDate,
        EmployeeRole role,
        string? phone,
        string? departmentName)
    {
        return new EmployeeDetails(id, companyId, firstName, lastName, email, position, status, joiningDate, role, phone, departmentName);
    }
}