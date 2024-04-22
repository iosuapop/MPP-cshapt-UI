namespace Donations.domain;

public class Entity<ID>
{
    public Entity(ID id)
    {
        Id = id;
    }

    public ID Id { get; set; }
}