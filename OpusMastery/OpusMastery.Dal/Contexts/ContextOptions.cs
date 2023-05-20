namespace OpusMastery.Dal.Contexts;

public class ContextOptions
{
    public required string ConnectionString { get; init; }
    public Guid? UserId { get; init; }
}