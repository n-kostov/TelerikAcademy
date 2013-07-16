using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AddProduct
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
                InsertProduct(dbCon, "qwerty3", 1, 1, "20 per kg", 20, 500, 50, 5, true);

            }
        }

        private static void InsertProduct(SqlConnection dbCon ,string name, int? supplier, int? category, string quantityPerUnit,
            decimal? unitPrice, int? unitsInStock, int? unitsOnOrder, int? reorderLevel, bool discontinued)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Products " +
              "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
            "VALUES " +
              "(@name, @supplier, @category, @quantity, @price, @unitsInStock, @unitsOnOrder, @reorder, @discontinued)", dbCon);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@discontinued", discontinued);

            CreateParameter(supplier, "@supplier", cmd);

            CreateParameter(category, "@category", cmd);

            CreateParameter(quantityPerUnit, "@quantity", cmd);

            CreateParameter(unitPrice, "@price", cmd);

            CreateParameter(unitsInStock, "@unitsInStock", cmd);

            CreateParameter(unitsOnOrder, "@unitsOnOrder", cmd);

            CreateParameter(reorderLevel, "@reorder", cmd);

            cmd.ExecuteNonQuery();
        }

        private static void CreateParameter(dynamic parameter,string parameterString, SqlCommand cmd)
        {
            SqlParameter sqlParameterSupplier =
              new SqlParameter(parameterString, parameter);
            if (parameter == null)
            {
                sqlParameterSupplier.Value = DBNull.Value;
            }

            cmd.Parameters.Add(sqlParameterSupplier);
        }

    }
}
