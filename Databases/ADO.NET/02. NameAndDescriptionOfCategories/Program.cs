using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NameAndDescriptionOfCategories
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
                  "SELECT CategoryName, Description FROM Categories ", dbCon);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string description = (string)reader["Description"];
                        Console.WriteLine("{0} - {1}", categoryName, description);
                    }
                }
            }
        }
    }
}
