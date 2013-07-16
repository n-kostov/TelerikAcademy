using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.AppendToExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Password="""";User ID=Admin;Data Source=..\..\scores.xlsx;Extended Properties=""HDR=YES;"";Jet OLEDB:Engine Type=37";

            OleDbConnection dbConn = new OleDbConnection(connectionString);

            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand(
                    "INSERT INTO [Scores$]([Name], [Score]) VALUES(@name, @score)", dbConn);
                cmd.Parameters.AddWithValue("@name", "qwerty");
                cmd.Parameters.AddWithValue("@score", 30.0);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
