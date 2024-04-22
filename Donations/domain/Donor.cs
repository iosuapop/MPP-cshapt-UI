namespace Donations.domain;

public class Donor : Entity<int>
{
    public Donor(int id, string name, string telephone, string address) : base(id)
    {
        Name = name;
        Telephone = telephone;
        Address = address;
    }

    public string Name { get; set; }
    public string Telephone { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"Donor{{id={Id}, name='{Name}', telephone='{Telephone}', address='{Address}'}}";
    }
}