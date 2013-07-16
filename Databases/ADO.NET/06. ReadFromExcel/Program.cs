using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReadFromExcel
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Password="""";User ID=Admin;Data Source=..\..\scores.xlsx;Mode=Share Deny Write;Extended Properties=""HDR=YES;"";Jet OLEDB:Engine Type=37";

            OleDbConnection dbConn = new OleDbConnection(connectionString);

            dbConn.Open();
            using (dbConn)
            {
                OleDbCommand cmd = new OleDbCommand(
                    "SELECT * FROM [Scores$]", dbConn);

                OleDbDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string fullName = (string)reader["Name"];
                    int score = (int)(double)reader["Score"];
                    Console.WriteLine("{0} - {1}", fullName, score);
                }
            }
        }
    }
}
