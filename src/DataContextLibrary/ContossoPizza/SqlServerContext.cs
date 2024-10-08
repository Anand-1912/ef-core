﻿using DataModelLibrary.ContossoPizza;
using Microsoft.EntityFrameworkCore;

namespace DataContextLibrary.ContossoPizza;

public class SqlServerContext: DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=ContossoPizza;Integrated Security=True;");
    }
}
