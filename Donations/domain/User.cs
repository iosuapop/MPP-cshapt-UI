namespace Donations.domain;

public class User : Entity<int>
{
    public User(int id, string name, string password) : base(id)
    {
        Name = name;
        Password = password;
    }

    public string Name { get; set; }
    public string Password { get; set; }

    public override string ToString()
    {
        return "User {id: " + Id + ", name: " + Name + ", password: " + Password + "}";
    }
}