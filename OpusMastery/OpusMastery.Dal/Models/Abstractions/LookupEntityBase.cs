namespace OpusMastery.Dal.Models.Abstractions;

public abstract class LookupEntityBase : EntityBase
{
    public string Name { get; set; } = null!;
}