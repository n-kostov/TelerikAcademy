using StudentSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace StudentSystem.ServiceLayer.Models
{
    public class SchoolModel
    {
        private IEnumerable<StudentModel> students;

        public SchoolModel()
        {
            this.students = new HashSet<StudentModel>();
        }

        public static Expression<Func<School, SchoolModel>> FromSchool
        {
            get
            {
                return x => new SchoolModel
                {
                    SchoolId = x.SchoolId,
                    Name = x.Name,
                    Location = x.Location,
                    Students = from y in x.Students
                               select new StudentModel
                               {
                                   StudentId = y.StudentId,
                                   FirstName = y.FirstName,
                                   LastName = y.LastName,
                                   Age = y.Age,
                                   Grade = y.Grade,
                                   Marks = y.Marks,
                                   SchoolId = x.SchoolId
                               }
                };
            }
        }

        public int SchoolId { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public IEnumerable<StudentModel> Students
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