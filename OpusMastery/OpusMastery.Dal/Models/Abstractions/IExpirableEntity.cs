namespace OpusMastery.Dal.Models.Abstractions;

public interface IExpirableEntity
{
    public DateTime ExpiresOn { get; set; }
}