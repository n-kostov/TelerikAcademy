namespace _01.StudentSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<_01.StudentSystem.StudentSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(_01.StudentSystem.StudentSystemContext context)
        {
            Random randomNumberGenerator = new Random();
            for (int i = 0; i < 100; i++)
            {
                context.Homeworks.AddOrUpdate(new Homework { TimeSpent = randomNumberGenerator.Next() });
            }

            context.SaveChanges();

            for (int i = 0; i < 100; i++)
            {
                int studentId = randomNumberGenerator.Next();

                var student = new Student()
                {
                    Name = "Student" + studentId,
                    Number = studentId,
                    HomeworkId = randomNumberGenerator.Next(1,100)
                };

                context.Students.AddOrUpdate(student);

                int courseId = randomNumberGenerator.Next();
                var course = new Course
                {
                    Name = "Course" + courseId,
                    HomeworkId = randomNumberGenerator.Next(1,100)
                };

                bool hasConnectionBetweenCourseAndStudent;
                if (studentId < courseId)
                {
                    hasConnectionBetweenCourseAndStudent = true;
                }
                else
                {
                    hasConnectionBetweenCourseAndStudent = false;
                }

                if (hasConnectionBetweenCourseAndStudent)
                {
                    student.Courses.Add(course);
                }
                else
                {
                    context.Courses.AddOrUpdate(course);
                }

                context.SaveChanges();
            }

            context.SaveChanges();
        }
    }
}
