using StudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.ServiceLayer.Models
{
    public class StudentModel
    {
        private ICollection<Mark> marks;

        public StudentModel()
        {
            this.marks = new HashSet<Mark>();
        }

        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return x => new StudentModel
                {
                    StudentId = x.StudentId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    Grade = x.Grade,
                    Marks = x.Marks,
                    School = x.School == null ? null :
                        new SchoolModel { SchoolId = x.School.SchoolId, Name = x.School.Name, Location = x.School.Location }
                };
            }
        }

        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public int SchoolId { get; set; }

        public ICollection<Mark> Marks
        {
            get
            {
                return this.marks;
            }
            set
            {
                this.marks = value;
            }
        }

        public SchoolModel School { get; set; }
    }
}