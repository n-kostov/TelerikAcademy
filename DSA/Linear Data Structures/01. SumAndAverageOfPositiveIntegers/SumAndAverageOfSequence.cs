using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAndAverageOfPositiveIntegers
{
    public class SumAndAverageOfSequence
    {
        public static void Main(string[] args)
        {
            List<int> positiveNumbers = new List<int>();
            string line;
            do
            {
                line = Console.ReadLine();
                int number;
                if (int.TryParse(line, out number) && number > 0)
                {
                    positiveNumbers.Add(number);
                }
            } 
            while (!string.IsNullOrWhiteSpace(line));

            Console.WriteLine("The sum of all positive numbers in the list is: {0}", positiveNumbers.Sum());
            Console.WriteLine("The average of the positive numbers is: {0}", positiveNumbers.Average());
        }
    }
}
