using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedList studentRecords = new SortedList();

            studentRecords.Add("John");
            studentRecords.Add("Peter");
            studentRecords.Add("George");
            studentRecords.Add("Paul");
            studentRecords.Add("Martin");

            studentRecords.SetSortingStrategy(new Quicksort());
            studentRecords.Sort();

            studentRecords.SetSortingStrategy(new MergeSort());
            studentRecords.Sort();

            Console.Read();
        }
    }
}
