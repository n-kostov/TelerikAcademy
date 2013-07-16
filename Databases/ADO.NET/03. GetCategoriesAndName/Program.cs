using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GetCategoriesAndName
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection dbCon = new SqlConnection(
              "Server=.; " +
              "Database=Northwind; " +
              "Integrated Security=true");

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT p.ProductName, c.CategoryName FROM Products p JOIN Categories c ON p.CategoryID = c.CategoryID", dbCon);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"];
                        string categoryName = (string)reader["CategoryName"];
                        Console.WriteLine("{0} - {1}", productName, categoryName);
                    }
                }
            }
        }
    }
}