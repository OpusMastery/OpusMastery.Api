using OpusMastery.Dal.Models.Abstractions;
using OpusMastery.Dal.Models.Identity;

namespace OpusMastery.Dal.Models;

public class Company : LookupEntityBase
{
    public required string Email { get; set; }
    public required string Status { get; set; }
    public string? PhoneNumber { get; set; }

    public Guid? ManagerId { get; set; }
    public SystemUser? Manager { get; set; }

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
}