using System;
using System.Linq;

namespace _07.ElementOccurrenceInArray
{
    public class ElementsOccurrences
    {
        public static void Main(string[] args)
        {
            int[] array = { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            var occurrences = array.GroupBy(x => x).OrderBy(x => x.Key);
            foreach (var element in occurrences)
            {
                Console.WriteLine("{0} => {1} times", element.Key, element.Count());
            }
        }
    }
}
