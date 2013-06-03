using System;
using System.Collections.Generic;
using System.Linq;

//  2.Define abstract class Human with first name and last name. Define new class Student which is derived from Human and 
//  has new field – grade. Define class Worker derived from Human with new property WeekSalary and WorkHoursPerDay and method
//  MoneyPerHour() that returns money earned by hour by the worker. Define the proper constructors and properties for this 
//  hierarchy. Initialize a list of 10 students and sort them by grade in ascending order 
//  (use LINQ or OrderBy() extension method). Initialize a list of 10 workers and sort them by money per hour in descending order.
//  Merge the lists and sort them by first name and last name.

namespace _2.HumanLists_SortAndMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] firstNames = { "Ivan", "Petur", "Niki", "Mara", "Ceko", "Ani", "Zoro", "Lucho", "Kalina", "Simeon" };
            string[] lastNames = { "Kostov", "Nakov", "Minkov", "Georgiev", "Kolev", "Jekov", "Andonov", "Tudjarov", "Pulev", "Cvetkov" };


            Console.WriteLine("------------Students--------------");

            Student[] students = new Student[10];
            for (int i = 0; i < students.Length; i++)
            {
                students[i] = new Student(firstNames[i], lastNames[i], 2 + i % 5);
            }

            foreach (var student in students)
            {
                Console.WriteLine("{0} {1} has grade {2}", student.FirstName, student.LastName, student.Grade);
            }

            Console.WriteLine("----------------Sorted Students--------------");
            students = students.OrderBy(x => x.Grade).ToArray();

            foreach (var student in students)
            {
                Console.WriteLine("{0} {1} has grade {2}", student.FirstName, student.LastName, student.Grade);
            }


            Console.WriteLine();
            Console.WriteLine("------------Workers--------------");

            Worker[] workers = new Worker[10];
            for (int i = 0; i < workers.Length; i++)
            {
                workers[i] = new Worker(firstNames[workers.Length - 1 - i], lastNames[i], 100 * i, 4 + i % 9);
            }

            foreach (var worker in workers)
            {
                Console.WriteLine("{0} {1} get {2}$ for {3} hours work", worker.FirstName, worker.LastName, worker.WeekSalary, 5 * worker.WorkHoursPerDay);
            }

            Console.WriteLine("----------------Sorted Workers--------------");
            workers = workers.OrderByDescending(x => x.MoneyPerHour()).ToArray();

            foreach (var worker in workers)
            {
                Console.WriteLine("{0} {1} get {2}$ for {3} hours work", worker.FirstName, worker.LastName, worker.WeekSalary, 5 * worker.WorkHoursPerDay);
            }


            Console.WriteLine();
            Console.WriteLine("------------Merged Humans--------------");

            List<Human> mergedList = new List<Human>();
            mergedList.AddRange(students.ToList());
            mergedList.AddRange(workers.ToList());

            foreach (var human in mergedList)
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }

            Console.WriteLine("----------------Sorted Humans--------------");
            mergedList = mergedList.OrderBy(x => x.FirstName).ThenBy(y => y.LastName).ToList();

            foreach (var human in mergedList)
            {
                Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
            }

        }
    }
}
