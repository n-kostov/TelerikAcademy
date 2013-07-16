using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace _09.BooksDB
{
    class Program
    {
        static string connectionString = "Server=localhost; Port=3306; Database=BookDB; Uid=root; Pwd=1234; pooling=true";

        static void Main(string[] args)
        {
            ListAllBooks();
            FindBookByName("The sun also rises");
            AddBook("Qwerty", "Qwertyson", DateTime.Parse("2001-12-14 14:00:00"), "saddf234d");
            AddBook("Ot zapada");
        }

        private static void ListAllBooks()
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            using (con)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Books", con);
                MySqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string title = (string)reader["Title"];
                        string author = (string)reader["Author"];
                        DateTime publishDate = (DateTime)reader["PublishDate"];
                        Console.WriteLine("\"{0}\" is written by {1} on {2}", title, author, publishDate);
                    }
                }
            }
        }

        private static void FindBookByName(string name)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            using (con)
            {
                MySqlCommand command = new MySqlCommand("SELECT * FROM Books WHERE Title = @name", con);
                command.Parameters.AddWithValue("@name", name);
                MySqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    Console.WriteLine("Books with title \"{0}\": ", name);
                    while (reader.Read())
                    {
                        string title = (string)reader["Title"];
                        string author = (string)reader["Author"];
                        DateTime publishDate = (DateTime)reader["PublishDate"];
                        Console.WriteLine("\"{0}\" is written by {1} on {2}", title, author, publishDate);
                    }
                }
            }
        }

        private static void AddBook(string title, string author = null, DateTime? publishDate = null, string isbn = null)
        {
            MySqlConnection con = new MySqlConnection(connectionString);
            con.Open();
            using (con)
            {
                MySqlCommand command = new MySqlCommand("INSERT INTO Books(Title, Author, PublishDate, ISBN) " + 
                "VALUES(@title, @author, @pdate, @isbn)", con);
                command.Parameters.AddWithValue("@title", title);
                CreateParameter(author, "@author", command);
                CreateParameter(publishDate, "@pdate", command);
                CreateParameter(isbn, "@isbn", command);
                command.ExecuteNonQuery();
            }
        }

        private static void CreateParameter(dynamic parameter, string parameterString, MySqlCommand cmd)
        {
            MySqlParameter mysqlParameterSupplier =
              new MySqlParameter(parameterString, parameter);
            if (parameter == null)
            {
                mysqlParameterSupplier.Value = DBNull.Value;
            }

            cmd.Parameters.Add(mysqlParameterSupplier);
        }
    }
}
