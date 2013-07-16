using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllProductsWithEscapingSpecialCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            SqlConnection dbCon = new SqlConnection(
              "Server=.; " +
              "Database=Northwind; " +
              "Integrated Security=true");

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT ProductName FROM Products WHERE ProductName LIKE @text ESCAPE @escapeChar", dbCon);
                command.Parameters.AddWithValue("@text", "%/" + text + "%");
                command.Parameters.AddWithValue("@escapeChar", "/");

                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string productName = (string)reader["ProductName"]; 
                        Console.WriteLine(productName);
                    }
                }
            }
        }
    }
}
