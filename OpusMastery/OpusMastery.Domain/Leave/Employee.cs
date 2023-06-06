namespace OpusMastery.Domain.Leave;

public class Employee
{
    public Guid EmployeeId { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }

    private Employee(Guid employeeId, string? firstName, string? lastName)
    {
        EmployeeId = employeeId;
        FirstName = firstName;
        LastName = lastName;
    }

    public static Employee Create(Guid employeeId, string? firstName = default, string? lastName = default)
    {
        return new Employee(employeeId, firstName, lastName);
    }
}