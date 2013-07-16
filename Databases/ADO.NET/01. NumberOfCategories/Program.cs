using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.NumberOfCategories
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
                  "SELECT COUNT(*) FROM Categories", dbCon);

                int categoriesCount = (int)command.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
            }
        }
    }
}
