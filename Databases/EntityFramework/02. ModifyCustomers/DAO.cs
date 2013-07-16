using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ModifyCustomers
{
    public static class DAOCustomer
    {
        public static string InsertCustomer(string customerId, string companyName)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customer = new Customer
            {
                CustomerID = customerId,
                CompanyName = companyName
            };

            context.Customers.Add(customer);
            context.SaveChanges();
            return customerId;
        }

        public static void UpdateCustomer(string customerId, Customer newCustomer)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customer = context.Customers.Where(x => x.CustomerID == customerId).FirstOrDefault();

            if (customer == null)
            {
                throw new ArgumentNullException("The customer you are looking for does not exist!");
            }

            customer.Address = newCustomer.Address;
            customer.City = newCustomer.City;
            customer.CompanyName = newCustomer.CompanyName;
            customer.ContactName = newCustomer.ContactName;
            customer.ContactTitle = newCustomer.ContactTitle;
            customer.Country = newCustomer.Country;
            customer.Fax = newCustomer.Fax;
            customer.Phone = newCustomer.Phone;
            customer.PostalCode = newCustomer.PostalCode;
            customer.Region = newCustomer.Region;

            context.SaveChanges();
        }

        public static void DeleteCustomer(string customerId)
        {
            NorthwindEntities context = new NorthwindEntities();
            Customer customer = context.Customers.Where(x => x.CustomerID == customerId).FirstOrDefault();
            context.Customers.Remove(customer);
            context.SaveChanges();
        }
    }
}
