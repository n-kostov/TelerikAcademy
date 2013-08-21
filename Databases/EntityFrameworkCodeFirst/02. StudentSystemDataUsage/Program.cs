using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.StudentSystem.Migrations;
using System.Data.Entity;
using _01.StudentSystem;

namespace _02.StudentSystemDataUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion
<StudentSystemContext, Configuration>());

            StudentSystemContext context = new StudentSystemContext();
            //context.Database.CreateIfNotExists();

            var homework = new Homework {HomeworkId = 101, TimeSpent = 15 };
            context.Homeworks.Add(homework);

            var course = new Course()
            {
                Name = "C#",
                HomeworkId = 1
            };
            context.Courses.Add(course);

            var student = new Student()
            {
                Name = "Pesho",
                Number = 1234,
                HomeworkId = 1
            };
            context.Students.Add(student);

            context.Courses.First().Students.Add(student);

            context.SaveChanges();
        }
    }
}
