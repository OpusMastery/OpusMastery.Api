using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class Company : LookupEntityBase
{
    public string Email { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string? PhoneNumber { get; set; }

    public Guid ManagerId { get; set; }
    public SystemUser Manager { get; set; } = null!;

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}