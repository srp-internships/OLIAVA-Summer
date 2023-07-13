using System;
using System.Data.Sql;
using System.Linq;

namespace SimpleDrinkMarket
{
    public class Program
    {
        static void Main(string[] args)
        {
            AddData();
        }

        static void AddData()
        {
            using (var context = new MarketContext())
            {

                context.CustomerOrders.Add(new CustomerOrder { Id = 1, Id_Customer = 1, Id_Procuct = 1, Price = 350, Quantity = 8 });

                context.SaveChanges();
                var product = context.CustomerOrders.ToList();

               // context.SaveChanges();
            }
        }

    }
}
