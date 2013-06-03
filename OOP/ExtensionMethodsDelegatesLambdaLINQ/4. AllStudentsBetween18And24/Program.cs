using System;
using System.Linq;

//  4.Write a LINQ query that finds the first name and last name of all students with age between 18 and 24.



namespace _4.AllStudentsBetween18And24
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]{
                new Student("Gosho", "Petkov", 5),
                new Student("Pesho","Tcanev", 18),
                new Student("Dimo", "Aleksiev", 24)
            };

            var filteredStudents =
                from student in students
                where student.Age >= 18 && student.Age <= 24
                select student;

            foreach (var student in filteredStudents)
            {
                Console.WriteLine("{0} {1} is {2} years old", student.FirstName, student.LastName, student.Age);
            }
        }
    }
}
