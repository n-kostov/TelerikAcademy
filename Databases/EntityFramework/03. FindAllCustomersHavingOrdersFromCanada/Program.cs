using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FindAllCustomersHavingOrdersFromCanada
{
    class Program
    {
        static void Main(string[] args)
        {
            FindAllCustomers(new DateTime(1997, 1, 1), "Canada");
        }

        static void FindAllCustomers(DateTime year, string country)
        {
            NorthwindEntities context = new NorthwindEntities();
            var customersWithOrders =
                from customer in context.Customers
                join order in context.Orders
                on customer.CustomerID equals order.CustomerID
                where order.ShipCountry == country && order.OrderDate.Value.Year == year.Year
                select new
                {
                    CustomerID = customer.CustomerID,
                    OrderDate = order.OrderDate,
                    ShipCountry = order.ShipCountry
                };

            foreach (var customer in customersWithOrders)
            {
                Console.WriteLine("{0} ordered on {1} from {2}", customer.CustomerID, customer.OrderDate, customer.ShipCountry);
            }
        }
    }
}
