using System;
using System.Linq;

//  6.Write a program that prints from given array of integers all numbers that are divisible by 7 and 3.
//  Use the built-in extension methods and lambda expressions. Rewrite the same with LINQ.

namespace _6.NumbersDivisibleBy7And3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };

            Console.WriteLine("-----------------Original---------------");
            foreach (var number in numbers)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();


            Console.WriteLine("-----------------Filtered with lambda---------------");
            var filteredWithLambda = numbers.Where(x => x % 3 == 0 || x % 7 == 0);
            foreach (var number in filteredWithLambda)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();


            Console.WriteLine("-----------------Filtered with LINQ---------------");
            var filteredWithLinq =
                from number in numbers
                where number % 3 == 0 || number % 7 == 0
                select number;
            foreach (var number in filteredWithLinq)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine();
        }
    }
}
