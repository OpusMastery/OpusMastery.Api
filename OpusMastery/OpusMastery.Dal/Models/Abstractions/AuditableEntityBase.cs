namespace OpusMastery.Dal.Models.Abstractions;

public abstract class AuditableEntityBase : EntityBase
{
    public DateTime? CreatedOn { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedOn { get; set; } = DateTime.UtcNow;
}