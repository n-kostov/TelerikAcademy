using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindAllCustomerHavingOrdersNativeSQL
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
            string nativeSQLQuery =
                "SELECT c.CustomerID, o.OrderDate, o.ShipCountry " +
                "FROM Customers c " +
                "JOIN Orders o " +
                "ON c.CustomerID = o.CustomerID " +
                "WHERE o.ShipCountry = {0} AND DATEPART(year, o.OrderDate) = DATEPART(year, {1})";

            var customersWithOrders = context.Database.SqlQuery<CustomerAndOrder>(nativeSQLQuery, country, year);

            foreach (var customer in customersWithOrders)
            {
                Console.WriteLine("{0} ordered on {1} from {2}", customer.CustomerID, customer.OrderDate, customer.ShipCountry);
            }
        }

        class CustomerAndOrder
        {
            public string CustomerID { get; set; }
            public DateTime OrderDate { get; set; }
            public string ShipCountry { get; set; }
        }
    }
}
