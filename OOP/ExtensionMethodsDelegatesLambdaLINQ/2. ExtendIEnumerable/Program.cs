using System;

//  2.Implement a set of extension methods for IEnumerable<T> that implement the following group functions:
//  sum, product, min, max, average.

namespace _2.ExtendIEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine(numbers.Max());
            Console.WriteLine(numbers.Min());
            Console.WriteLine(numbers.Average());
            Console.WriteLine(numbers.Sum());
            Console.WriteLine(numbers.Product());
        }
    }
}
