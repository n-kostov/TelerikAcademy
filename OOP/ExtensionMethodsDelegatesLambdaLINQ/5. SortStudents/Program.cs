using System;
using System.Linq;
using _3.FirstNameBeforeLastName;

//  5.Using the extension methods OrderBy() and ThenBy() with lambda expressions sort the students by first name and last name
//  in descending order. Rewrite the same with LINQ.

namespace _5.SortStudents
{
    class Program
    {
        static void Main(string[] args)
        {
            Student[] students = new Student[]{
                new Student("Pesho", "Ivanov"),
                new Student("Gosho", "Petkov"),
                new Student("Pesho","Tcanev"),
                new Student("Dimo", "Aleksiev")

            };

            Console.WriteLine("-------------Original------------");
            foreach (var student in students)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }


            Console.WriteLine("-------------Sorted with Lambda------------");
            var sortedWithLambda = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);
            foreach (var student in sortedWithLambda)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }


            Console.WriteLine("-------------Sorted with LINQ------------");
            var sortedWithLinq =
                from student in students
                orderby student.FirstName descending, student.LastName descending
                select student;
            foreach (var student in sortedWithLinq)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }
    }
}
