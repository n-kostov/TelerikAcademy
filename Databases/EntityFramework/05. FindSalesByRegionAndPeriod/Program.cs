using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FindSalesByRegionAndPeriod
{
    class Program
    {
        static void Main(string[] args)
        {
            FindAllOrders(null, new DateTime(1997, 5, 5), new DateTime(1997, 8, 8));
        }

        static void FindAllOrders(string region, DateTime? startDate, DateTime? endDate)
        {
            var context = new NorthwindEntities();
            (context as IObjectContextAdapter)
                .ObjectContext.ContextOptions.UseCSharpNullComparisonBehavior = true;
            var orders =
                from order in context.Orders
                where order.ShipRegion == region &&
                    order.OrderDate.Value >= startDate && order.OrderDate.Value <= endDate
                select order;

            foreach (var order in orders)
            {
                Console.WriteLine("{0} has ordered {1} on {2} and received the order on {3} in {4}",
                    order.CustomerID, order.OrderID,
                    order.OrderDate.Value,
                    order.ShippedDate.Value,
                    order.ShipRegion == null ? "NULL" : order.ShipRegion);
            }
        }
    }
}
