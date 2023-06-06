namespace OpusMastery.Domain.Leave;

public class Employee
{
    public Guid Id { get; private set; }
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }

    private Employee(Guid id, string? firstName, string? lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public static Employee Create(Guid id, string? firstName = default, string? lastName = default)
    {
        return new Employee(id, firstName, lastName);
    }
}