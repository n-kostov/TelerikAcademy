using System;
using System.Linq;

namespace _08.MajorantOfArray
{
    public class FindMajorant
    {
        public static void Main(string[] args)
        {
            int[] array = { 2, 3, 2, 3, 2 };
            int size = array.Length;

            var occurrences = array.GroupBy(x => x).OrderBy(x => -x.Count());
            var mostOccurringNumber = occurrences.First();  // get the number with the most occurrences

            if (mostOccurringNumber.Count() >= (size / 2) + 1)
            {
                Console.WriteLine("The majorant of the array is: " + mostOccurringNumber.Key);
            }
            else
            {
                Console.WriteLine("There is no majorant in this array!");
            }
        }
    }
}
