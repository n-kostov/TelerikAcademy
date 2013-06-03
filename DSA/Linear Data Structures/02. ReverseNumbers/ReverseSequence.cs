using System;
using System.Collections.Generic;

namespace _02.ReverseNumbers
{
    public class ReverseSequence
    {
        public static void Main(string[] args)
        {
            Stack<int> numbers = new Stack<int>();
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());

            if (n < 1)
            {
                Console.WriteLine("Cannot work with no numbers!");
                return;
            }

            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                numbers.Push(number);
            }

            Console.WriteLine("The numbers in reverse order are: ");

            while (numbers.Count != 0)
            {
                Console.WriteLine(numbers.Pop());
            }
        }
    }
}
