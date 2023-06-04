namespace OpusMastery.Domain.Employee;

public class EmployeeRole
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private EmployeeRole(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static EmployeeRole Create(Guid id, string name)
    {
        return new EmployeeRole(id, name);
    }
}