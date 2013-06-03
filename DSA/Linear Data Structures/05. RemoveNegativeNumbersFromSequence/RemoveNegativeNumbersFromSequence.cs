using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.RemoveNegativeNumbersFromSequence
{
    public class RemoveNegativeNumbersFromSequence
    {
        public static void RemoveAllNegativeNumbersFromSequence(List<int> sequence)
        {
            sequence.RemoveAll(x => x < 0);
        }

        public static void Main(string[] args)
        {
            List<int> sequence = new List<int> { 0, 4, -1, 6, -2 };
            Console.WriteLine("The initial sequence is: ");
            Console.WriteLine(string.Join(", ", sequence));

            Console.WriteLine("The sequence without negative numbers: ");
            RemoveAllNegativeNumbersFromSequence(sequence);
            Console.WriteLine(string.Join(", ", sequence));
        }
    }
}
