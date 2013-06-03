using System;
using System.Collections.Generic;

namespace _09.PrintSequence
{
    public class PrintSequence
    {
        public static void PrintInfiniteSequence(int n, int size)
        {
            Queue<int> sequence = new Queue<int>();
            sequence.Enqueue(n);

            for (int i = 0; i < size; i++)
            {
                int currentElement = sequence.Dequeue();
                sequence.Enqueue(currentElement + 1);
                sequence.Enqueue((2 * currentElement) + 1);
                sequence.Enqueue(currentElement + 2);
                Console.WriteLine("S{0} = {1}", i + 1, currentElement);
            }
        }

        public static void Main(string[] args)
        {
            PrintInfiniteSequence(2, 50);
        }
    }
}
