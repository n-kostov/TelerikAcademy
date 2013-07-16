using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace _04.StoreImages
{
    class Program
    {
        static void Main(string[] args)
        {
            int fileOffset = 78;

            SqlConnection dbCon = new SqlConnection(
              "Server=.; " +
              "Database=Northwind; " +
              "Integrated Security=true");

            dbCon.Open();
            using (dbCon)
            {
                SqlCommand command = new SqlCommand(
                  "SELECT Picture FROM Categories", dbCon);
                SqlDataReader reader = command.ExecuteReader();
                using (reader)
                {
                    int count = 1;
                    while (reader.Read())
                    {
                        byte[] imageData = reader["Picture"] as byte[];
                        MemoryStream stream = new MemoryStream(
                            imageData, fileOffset,
                            imageData.Length - fileOffset);

                        Image image = Image.FromStream(stream);
                        using (image)
                        {
                            image.Save("image" + count + ".jpg", ImageFormat.Jpeg);
                        }

                        count++;
                    }
                }
            }
        }
    }
}