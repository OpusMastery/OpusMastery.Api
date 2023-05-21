using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models;

public class SystemUser : EntityBase
{
    public string Email { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string? Password { get; set; }
    public string? MiddleName { get; set; }

    public Guid RoleId { get; set; }
    public SystemUserRole Role { get; set; } = null!;
}