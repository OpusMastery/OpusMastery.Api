using OpusMastery.Dal.Models.Abstractions;

namespace OpusMastery.Dal.Models.Identity;

public class SystemUserRefreshToken : EntityBase, IExpirableEntity
{
    public required DateTime ExpiresOn { get; set; }

    public required string Value { get; set; }
    public required Guid UserId { get; set; }
    public SystemUser User { get; set; } = null!;
}