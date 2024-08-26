using DataModelLibrary.ContossoPizza;
using Microsoft.EntityFrameworkCore;

namespace DataContextLibrary.ContossoPizza;

public class PostgreSqlContext : DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=postgres;Username=root;Password=secret;Pooling=false;Timeout=300;CommandTimeout=300;");
    }
}
