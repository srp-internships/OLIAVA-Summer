
using System.Data.Entity;

namespace SimpleDrinkMarket
{
    public class MarketContext : DbContext
    {
        public MarketContext() : base("name=DefaultConnection") 
        {
            Database.SetInitializer(new MarketContextInitializer());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<MarketOrder> MarketOrders { get; set; }
        static MarketContext() 
        {
           
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
