namespace CarRental.Core.Domain.Entities;

// Models/Car.cs
// Машины, изначально принадлежащие компании (whose = NULL), не арендованы (rented = NULL)

public class Car
{ 
    public string Id { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string? Rented { get; set; } // transaction_id(FK → Transactions) или null
    public string? Whose { get; set; } // transaction_id(FK → Transactions) или null
    
    public Car() {}

    public Car(string id, string brand, string model, string color, string? rented, string? whose)
    {
        Id = id;
        Brand = brand;
        Model = model;
        Color = color;
        Rented = rented;
        Whose = whose;
    }
}
