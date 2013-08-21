using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using StudentSystem.Model;

namespace StudentSystem.DataLayer
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentsDb")
        {
            //base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Mark> Marks { get; set; }
        public DbSet<School> Schools { get; set; }
    }
}
