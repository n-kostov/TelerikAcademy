using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ModifyCustomers
{
    class Program
    {
        static void Main(string[] args)
        {
            DAOCustomer.InsertCustomer("QWE", "QWERTY");
            Customer customer = new Customer
            {
                CustomerID = "QWE",
                CompanyName = "QWERTY",
                ContactName = "Someone",
                ContactTitle = "Manager",
                Address = "Home",
                City = "Murica",
                Region = "Earth",
                PostalCode = "1234",
                Country = "Murica",
                Phone = "555-murica-555",
                Fax = "not using"
            };

            DAOCustomer.UpdateCustomer("QWE", customer);
            DAOCustomer.DeleteCustomer("QWE");
        }


    }
}
