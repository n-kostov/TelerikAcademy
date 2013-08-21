using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CodeJewels.Models;

namespace CodeJewels.Data
{
    public class CodeJewelDataContext : DbContext
    {
        public CodeJewelDataContext()
            : base("CodeJewelsDb")
        {

        }

        public DbSet<Vote> Votes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CodeJewel> CodeJewels { get; set; }
    }
}
