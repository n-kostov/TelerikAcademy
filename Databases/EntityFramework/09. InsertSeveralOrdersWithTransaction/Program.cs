using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _09.InsertSeveralOrdersWithTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var transaction = new TransactionScope())
            {
                try
                {
                    InsertDuplicateOrders();
                    InsertDifferentOrders();
                    transaction.Complete();
                }
                catch (System.Exception)
                {
                    Console.WriteLine("Cannot complete the current transaction because the order already exists! Rollback!");
                }
            }
        }

        static void InsertDuplicateOrders()
        {
            NorthwindEntities context = new NorthwindEntities();
            Order order = new Order
            {
                OrderID = 1,
                CustomerID = "QWE"
            };

            Order order2 = new Order
            {
                OrderID = 1,
                CustomerID = "QWE"
            };

            context.Orders.Add(order);
            context.Orders.Add(order2);
            context.SaveChanges();
        }

        static void InsertDifferentOrders()
        {
            NorthwindEntities context = new NorthwindEntities();
            Order order1 = new Order
            {
                OrderID = 2,
                CustomerID = "QWE",
            };

            Order order2 = new Order
            {
                OrderID = 3,
                CustomerID = "QWE"
            };

            context.Orders.Add(order1);
            context.Orders.Add(order2);
            context.SaveChanges();
        }
    }
}
