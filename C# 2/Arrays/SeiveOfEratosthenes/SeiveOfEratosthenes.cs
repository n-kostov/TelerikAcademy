using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class SeiveOfEratosthenes
{
    static void Main()
    {
        int n = 10000000;
        bool[] list = new bool[n];

        for (int i = 0; i < n; i++)
        {
            list[i] = true;
        }
        for (int i = 3; i < n; i += 2)
        {
            list[i] = false;
        }
        for (int i = 3; i <= Math.Sqrt(n); i += 2)
        {
            for (int j = (int)Math.Pow(i, 2) - 1; j < n; j += i)
            {
                list[j] = false;
            }
        }
        Console.WriteLine(2);
        for (int i = 2; i < n; i += 2)
        {
            if (list[i] == true)
            {
                Console.WriteLine(i + 1);
            }
        }
    }
}

