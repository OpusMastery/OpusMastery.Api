namespace OpusMastery.Domain.Identity;

public class UserRole
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private UserRole(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static UserRole Create(Guid id, string name)
    {
        return new UserRole(id, name);
    }
}