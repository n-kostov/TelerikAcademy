using System;
using System.Linq;

//  3.Write a method that from a given array of students finds all students whose first name is before its last name alphabetically.
//  Use LINQ query operators.

namespace _3.FirstNameBeforeLastName
{
    class Program
    {
        public static void FindAllStudentsWhoseFirstNameIsBeforeTheirLastNAme(Student[] students)
        {
            var filteredStudents = students.Where(x => x.FirstName.CompareTo(x.LastName) < 0);
            foreach (var student in filteredStudents)
            {
                Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
            }
        }

        static void Main(string[] args)
        {
            Student[] students = new Student[]{
                new Student("Gosho", "Petkov"),
                new Student("Pesho","Tcanev"),
                new Student("Dimo", "Aleksiev")
            };
            FindAllStudentsWhoseFirstNameIsBeforeTheirLastNAme(students);
        }
    }
}
