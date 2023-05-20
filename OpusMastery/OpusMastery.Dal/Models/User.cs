using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class User : AuditableEntityBase
{
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string Password { get; set; } = null!;
    
    public Guid RoleId { get; set; }
    public UserRole Role { get; set; } = null!;
}