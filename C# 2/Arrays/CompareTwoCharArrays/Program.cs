using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareTwoCharArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            char[] firstString = new char[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("firstString[{0}] = ", i);
                firstString[i] = char.Parse(Console.ReadLine());
            }
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            char[] secondString = new char[k];
            for (int i = 0; i < k; i++)
            {
                Console.Write("secondString[{0}] = ", i);
                secondString[i] = char.Parse(Console.ReadLine());
            }
            bool compared = true;
            string first = new string(firstString);
            string second = new string(secondString);
            for (int i = 0; i < n && i < k; i++)
            {
                if (firstString[i] > secondString[i])
                {
                    Console.WriteLine("\"{0}\" is lexicographically ahead than \"{1}\"", second, first);
                    compared = false;
                    break;
                } 
                else if(firstString[i] < secondString[i])
                {
                    Console.WriteLine("\"{0}\" is lexicographically ahead than \"{1}\"", first, second);
                    compared = false;
                    break;
                }
                else
                {
                    continue;
                }
            }
            if (compared)
            {
                if (n < k)
                {
                    Console.WriteLine("\"{0} is lexicographically ahead than \"{1}\"", first, second);
                } 
                else if(n > k)
                {
                    Console.WriteLine("\"{0}\" is lexicographically ahead than \"{1}\"", second, first);
                }
                else
                {
                    Console.WriteLine("\"{0}\" is lexicographically equal to \"{1}\"", first, second);
                }
            } 
        }
    }
}
