using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.CreateDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities context = new NorthwindEntities();
            context.Database.CreateIfNotExists();
        }
    }
}
