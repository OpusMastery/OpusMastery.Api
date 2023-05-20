using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class UserRole : AuditableEntityBase
{
    public string Name { get; set; } = null!;

    public ICollection<User> Users { get; set; } = new List<User>();
}