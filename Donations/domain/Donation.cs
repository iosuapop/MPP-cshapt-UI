namespace Donations.domain;

public class Donation : Entity<int>
{
    public Donation(int id, Charity charity, Donor donor, float amount) : base(id)
    {
        Charity = charity;
        Donor = donor;
        Amount = amount;
    }

    public Charity Charity { get; set; }
    public Donor Donor { get; set; }
    public float Amount { get; set; }

    public override string ToString()
    {
        return $"Donations{{id={Id}, charity={Charity}, donor={Donor}, amount={Amount}}}";
    }
}