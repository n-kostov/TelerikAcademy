using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentSystem
{
    public class Homework
    {
        private ICollection<Student> students;
        private ICollection<Course> courses;

        public Homework()
        {
            students = new HashSet<Student>();
            courses = new HashSet<Course>();
        }

        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public int TimeSpent { get; set; }

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

        public virtual ICollection<Course> Courses
        {
            get
            {
                return this.courses;
            }
            set
            {
                this.courses = value;
            }
        }
    }
}
