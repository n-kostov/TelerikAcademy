using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.RemoveNumbersOccurringOddNumberOfTimes
{
    public class RemoveNumbersOccurringOddNumberOfTimes
    {
        public static void RemoveAllNumbersOccurringOddNumberOfTimes(List<int> sequence)
        {
            List<int> elementsToExclude = new List<int>();
            foreach (var number in sequence)
            {
                if (elementsToExclude.Contains(number))
                {
                    elementsToExclude.Remove(number);
                }
                else
                {
                    elementsToExclude.Add(number);
                }
            }

            foreach (var number in elementsToExclude)
            {
                sequence.RemoveAll(x => x == number);
            }
        }

        public static void Main(string[] args)
        {
            List<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };
            Console.WriteLine("The initial sequence is: ");
            Console.WriteLine(string.Join(", ", sequence));

            Console.WriteLine("The sequence without numbers occurring odd number of times: ");
            RemoveAllNumbersOccurringOddNumberOfTimes(sequence);
            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
