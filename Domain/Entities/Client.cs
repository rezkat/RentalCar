namespace CarRental.Core.Domain.Entities;

// Models/Client.cs
public class Client
{
    public string Id { get; set; }
    public string FullName { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }

    public Client() {}

    public Client(string id, string fullName, string address, string email)
    {
        Id = id;
        FullName = fullName;
        Address = address;
        Email = email;
    }
}

