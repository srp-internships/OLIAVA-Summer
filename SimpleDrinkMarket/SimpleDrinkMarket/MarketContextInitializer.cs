
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace SimpleDrinkMarket
{
    public class MarketContextInitializer : CreateDatabaseIfNotExists<MarketContext> 
    {
        protected override void Seed(MarketContext marketContext)
        {
            marketContext.Products.Add(new Product { Id = 1, Name = "CocaCola" });
            marketContext.Products.Add(new Product { Id = 2, Name = "Pepsi" });
            marketContext.Products.Add(new Product { Id = 3, Name = "Fanta" });
            marketContext.Products.Add(new Product { Id = 4, Name = "Sprite" });
            marketContext.Products.Add(new Product { Id = 5, Name = "Limonade" });

            marketContext.Customers.Add(new Customer { Id = 1, Name = "John" });
            marketContext.Customers.Add(new Customer { Id = 2, Name = "Daniel" });
            marketContext.Customers.Add(new Customer { Id = 3, Name = "Alice" });
            marketContext.Customers.Add(new Customer { Id = 4, Name = "Tom" });

            marketContext.Providers.Add(new Provider { Id = 1, Name = "7Ganj" });
            marketContext.Providers.Add(new Provider { Id = 2, Name = "CocaCola" });

            marketContext.CustomerOrders.Add(new CustomerOrder { Id = 1, Id_Customer = 1, Id_Procuct = 1, Price = 350, Quantity = 8 });

            marketContext.SaveChanges();
        }
    }
}
