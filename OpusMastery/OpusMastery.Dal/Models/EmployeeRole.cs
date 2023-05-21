using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class EmployeeRole : LookupEntityBase
{
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}