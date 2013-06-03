using System;
using System.Collections.Generic;

namespace _03.SortSequenceOfNumbers
{
    public class SortSequence
    {
        public static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            string line;
            do
            {
                line = Console.ReadLine();
                int number;
                if (int.TryParse(line, out number))
                {
                    numbers.Add(number);
                }
            }
            while (!string.IsNullOrWhiteSpace(line));

            Console.WriteLine("The sequence before the sort is: ");
            Console.WriteLine(string.Join(" ", numbers));

            numbers.Sort();

            Console.WriteLine("The sequence after the sort is: ");
            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
