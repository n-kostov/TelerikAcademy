// aka - Find longest increasing sequence algorithm

using System;
using System.Collections.Generic;

class RemoveMinimalToSortArray
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int[] array = new int[n];
        Console.WriteLine("lets enter the array");
        for (int i = 0; i < n; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        int[] s = new int[n];
        int index = 0;
        s[0] = index;
        // s stores at which position the next element will be
        for (int i = 1; i < n; i++)
        {
            if (array[i] < array[s[index]])
            {
                for (int j = 0; j <= index; j++)
                {
                    if (array[i] < array[s[j]])
                    {
                        s[j] = i;
                        break;
                    }
                }
            }
            else
            {
                s[++index] = i;
            }
        }

        int[] lis = new int[index + 1];
        lis[index] = array[s[index]];

        for (int i = index - 1; i >= 0; i--)
        {
            if (s[i] < s[i + 1])
            {
                lis[i] = array[s[i]];
            }
            else
            {
                // repair existing s elements
                for (int j = s[i + 1] - 1; j >= 0; j--)
                {
                    if (array[j] >= array[s[i]] && array[j] <= array[s[i + 1]])
                    {
                        lis[i] = array[j];
                        s[i] = j;
                        break;
                    }
                }
            }
        }

        for (int i = 0; i < lis.Length; i++)
        {
            Console.Write(lis[i] + " ");
        }
        Console.WriteLine();
    }
}

