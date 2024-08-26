// See https://aka.ms/new-console-template for more information
using DataContextLibrary.ContossoPizza;
using DataModelLibrary.ContossoPizza;

Console.WriteLine("Contosso Pizza Shop!");

#region - Sql Server

using SqlServerContext sqlContossoContext = new();

#region Insert
Product veggieSpecial = new()
{
    Name = "Veggie Special Pizza",
    Price = 9.99M
};

Product deluxeMeat = new()
{
    Name = "Deluxe Meat Pizza",
    Price = 12.99M
};

//sqlContossoContext.Products.Add(veggieSpecial);
//sqlContossoContext.Products.Add(deluxeMeat);
//sqlContossoContext.SaveChanges();
#endregion Insert

#region Read
//Fluent Query

var products = sqlContossoContext.
               Products.
               Where(p => p.Price > 10.00M).
               OrderBy(p => p.Name);

foreach (var product in products)
{
    Console.WriteLine($"Id: {product.Id}");
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine(new string('-', 20));
}

// Linq

var products2 = from product in products
                where product.Price > 10.00M
                orderby product.Name
                select product;

foreach (var product in products)
{
    Console.WriteLine($"Id: {product.Id}");
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine(new string('-',20));
}
#endregion Read

#region Update
var veggieSpecialPizza = sqlContossoContext.
                         Products.
                         Where(p => p.Name == "Veggie Special Pizza").
                         FirstOrDefault();

if(veggieSpecialPizza is Product)
{
    veggieSpecialPizza.Price = 10.99M;
}

sqlContossoContext.SaveChanges();
#endregion Update

#region Delete

//if (veggieSpecialPizza is Product)
//{
//    sqlContossoContext.Products.Remove(veggieSpecialPizza);
//}
//sqlContossoContext.SaveChanges();
#endregion Delete


#endregion

#region - PostgreSql

Console.WriteLine(new string('-', 20));
Console.WriteLine("PstgreSql");
Console.WriteLine(new string('-',20));

using PostgreSqlContext postgreSqlContossoContext = new();

#region Insert
postgreSqlContossoContext.Add(veggieSpecial);
postgreSqlContossoContext.Add(deluxeMeat);
postgreSqlContossoContext.SaveChanges();
#endregion Insert

#region Read
//Fluent Query
var products_from_postgres = postgreSqlContossoContext.
                             Products.
                             Where(p => p.Price > 10.00M).
                             OrderBy(p => p.Name);
foreach (var product in products_from_postgres)
{
    Console.WriteLine($"Id: {product.Id}");
    Console.WriteLine($"Name: {product.Name}");
    Console.WriteLine($"Price: {product.Price}");
    Console.WriteLine(new string('-', 20));
}
#endregion Read
#endregion