using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ProvadiaNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            List<string> list = new List<string>();
            if (number == 0)
            {
                Console.Write('A');
            }
            while (number > 0)
            {
                int num = (int)(number % 256);
                if (num / 26 > 0)
                {
                    list.Add(((char)((char)(num % 26) + 'A')).ToString());
                    list.Add(((char)((char)(num / 26) + 'a' - 1)).ToString());
                } 
                else
                {
                    list.Add(((char)((char)(num % 26) + 'A')).ToString());
                }
                number /= 256;
            }
            for (int i = list.Count - 1; i >= 0; i--)
            {
                Console.Write(list[i]);
            }
        }
    }
}
