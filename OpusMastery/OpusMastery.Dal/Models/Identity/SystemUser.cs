using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models.Identity;

public class SystemUser : EntityBase, IAuditableEntity
{
    public DateTime? CreatedOn { get; set; }
    public Guid? CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public Guid? ModifiedBy { get; set; }

    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? MiddleName { get; set; }
    public required string Status { get; set; }

    public required Guid RoleId { get; set; }
    public SystemUserRole Role { get; set; } = null!;

    public Guid? RefreshTokenId { get; set; }
    public SystemUserRefreshToken? RefreshToken { get; set; }
}