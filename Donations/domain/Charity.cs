namespace Donations.domain;

public class Charity : Entity<int>
{
    public Charity(int id, string description) : base(id)
    {
        Description = description;
    }

    public string Description { get; set; }

    public override string ToString()
    {
        return $"Charity{{id={Id}, name='{Description}'}}";
    }
}