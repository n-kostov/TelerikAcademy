using System;

namespace _5.HashSet
{
    public class HashSetDemo
    {
        public static void Main(string[] args)
        {
            HashSet<int> first = new HashSet<int>();
            first.Add(1);
            first.Add(2);
            first.Add(3);

            Console.Write("First set: ");
            foreach (var item in first)
            {
                Console.Write(item.Key + " ");
            }

            Console.WriteLine();

            HashSet<int> second = new HashSet<int>();
            second.Add(4);
            second.Add(1);
            second.Remove(1);

            Console.Write("Second set: ");
            foreach (var item in second)
            {
                Console.Write(item.Key + " ");
            }

            Console.WriteLine();

            first.Union(second);

            Console.Write("Sets union: ");
            foreach (var item in first)
            {
                Console.Write(item.Key + " ");
            }

            Console.WriteLine();

            //second.Add(1);

            first.Intersect(second);

            Console.Write("Sets intersection: ");
            foreach (var item in first)
            {
                Console.Write(item.Key + " ");
            }

            Console.WriteLine();
        }
    }
}
