using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models.Identity;

public class SystemUserVerificationCode : EntityBase, IExpirableEntity
{
    public required DateTime ExpiresOn { get; set; }

    public required string Code { get; set; }
    public required Guid UserId { get; set; }
    public SystemUser User { get; set; } = null!;
}