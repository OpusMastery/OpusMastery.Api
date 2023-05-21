namespace OpusMastery.Dal.Models.Abstractions;

public abstract class LookupEntityBase : AuditableEntityBase
{
    public string Name { get; set; } = null!;
}