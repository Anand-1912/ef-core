﻿namespace DataModelLibrary.ContossoPizza;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public ICollection<Order> Orders { get; set; } = null!;
}
