# EF Core

## Packages Required

#### Microsoft.EntityFrameworkCore
   
- DBContext class has been defined here

#### Microsoft.EntityFrameworkCore.SqlServer

- Microserver Sql Server EFCore Provider

#### Microsoft.EntityFrameworkCore.Design

#### Microsoft.EntityFrameworkCore.Tools


### Model

```csharp

public class Product
{
    public int Id { get; set; }  // key
    public string Name { get; set; } = null!;
    [Column(TypeName = "decimal(6, 2)")]
    public decimal Price { get; set; }
}

/*

 In EFCore, The Property named Id or <TableName>Id will be considered as Primary Key of the Table.
 Otherwise the Property needs to be annotated with [Key] attribute

*/
```

```csharp

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public ICollection<Order> Orders { get; set; } = null!; //Navigation Property
}

/*

 A Customer can have zero or more Orders. 
 This creates 1 to many relationship in the database.

*/
```

``` csharp

public class Order
{
        public int Id { get; set; }
        public DateTime OrderPlaced { get; set; }
        public DateTime OrderFulfilled { get; set; } 
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
        public ICollection<OrderDetail> OrderDetails { get; set; } = null!;
}

/*
Here, 

1. Customer Property indicates that One Order Entity is mapped to only one Customer Entity.
2. Customer Id represents the foreign key however it is optional and 
   if it is not provided, EFCore will create a Shadow Property.

*/
```

### Database Context

```csharp

public class SqlServerContext: DbContext
{
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<OrderDetail> OrderDetails { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"connection string here");
    }
}

/*

Here, 
1. Each DbSet maps to a table in the SQL Server
2. OnConfiguring Method has been overridden to configure 
   the Sql Server instance that needs to be used by the context

*/

```
### Migrations

```sh

## USING DOTNET CLI

    dotnet tool install -g dotnet-ef

    dotnet ef migrations add InitialCreate

    dotnet ef database update

## USING PACKAGE MANAGER CONSOLE IN VISUAL STUDIO

    Add-Migration InitalCreate

    Update-Database

```

## Providers

### PostgreSQL Provider

`Reference`: [Npgsql-docker-compose](https://dev.to/geoff89/how-to-deploy-postgresql-with-docker-and-docker-compose-3lj3)

`package`: Npgsql.EntityFrameworkCore.PostgreSQL

### Running Migrations when multiple contexts available.

```sh

## USING DOTNET CLI

    dotnet ef migrations add InitialCreate --context PostgreSqlContext --output-dir Migrations/PostgresMigrations

    dotnet ef database update --context PostgreSqlContext

## USING PACKAGE MANAGER CONSOLE IN VISUAL STUDIO

    Add-Migration InitialCreate -Context PostgreSqlContext -OutputDir Migrations/PostgresMigrations

    Update-Database -Context PostgreSqlContext

```




