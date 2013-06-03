using System;
using System.Collections.Generic;

class Factorial
{

    static void Multiply(int number, List<int> list)
    {
        int offset = 0;
        for (int i = list.Count - 1; i >= 0; i--)
        {
            int sum = list[i] * number;
            int k = offset;
            while (offset > 0)
            {
                offset--;
                i++;
            }
            while (k > 0)
            {
                list[i] += sum % 10;
                sum /= 10;
                sum += list[i] / 10;
                list[i] %= 10;
                k--;
                i--;
            }

            while (sum > 9)
            {
                list.Insert(++i, sum % 10);
                i--;
                sum /= 10;
                offset++;
            }
            list[i] = sum;
        }
    }

    static void Main()
    {
        List<int> list = new List<int>();
        list.Add(1);
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 2; i <= n; i++)
        {
            Multiply(i, list);
        }
        foreach (int item in list)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

