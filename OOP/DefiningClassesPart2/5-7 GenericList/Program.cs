using System;

namespace _5_7_GenericList
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericList<int> list = new GenericList<int>(3);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.InsertAt(0, 10);
            list.Remove(1);
            list.InsertAt(2, 0);
            Console.WriteLine(list[4]);
            Console.WriteLine(list);
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
        }
    }
}
