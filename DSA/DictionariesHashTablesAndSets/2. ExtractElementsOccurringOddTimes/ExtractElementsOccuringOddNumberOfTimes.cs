using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ExtractElementsOccurringOddTimes
{
    public class ExtractElementsOccuringOddNumberOfTimes
    {
        public static void Main(string[] args)
        {
            string[] array = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            IDictionary<string, int> occurrences = new Dictionary<string, int>();

            for (int i = 0; i < array.Length; i++)
            {
                if (occurrences.ContainsKey(array[i]))
                {
                    occurrences[array[i]]++;
                }
                else
                {
                    occurrences[array[i]] = 1;
                }
            }

            Console.WriteLine("Original sequence: {" + string.Join(", ", array) + "}");
            var oddOccurrences = occurrences.Keys.Where(x => occurrences[x] % 2 == 1);
            Console.WriteLine("Elements occuring odd number of times: {" + string.Join(", ", oddOccurrences.ToArray()) + "}");
        }
    }
}
