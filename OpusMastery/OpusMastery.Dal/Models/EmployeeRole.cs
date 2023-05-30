using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class EmployeeRole : EntityBase, INameableEntity
{
    public required string Name { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}