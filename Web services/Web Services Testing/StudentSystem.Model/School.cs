using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystem.Model
{
    public class School
    {
        private ICollection<Student> students;

        public School()
        {
            this.students = new HashSet<Student>();
        }

        public int SchoolId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public virtual ICollection<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }
    }
}
