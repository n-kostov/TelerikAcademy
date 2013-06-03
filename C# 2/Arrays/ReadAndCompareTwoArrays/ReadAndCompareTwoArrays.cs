using System;

class ReadAndCompareTwoArrays
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        int[] firstArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("firstArray[{0}] = ", i);
            firstArray[i] = int.Parse(Console.ReadLine());
        }
        int[] secondtArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("secondArray[{0}] = ", i);
            secondtArray[i] = int.Parse(Console.ReadLine());
        }
        bool equal = true;
        for (int i = 0; i < n; i++)
        {
            if (firstArray[i] != secondtArray[i])
            {
                equal = false;
                break;
            }
        }
        if (equal)
        {
            Console.WriteLine("The arrays are equal");
        }
        else
        {
            Console.WriteLine("The arrays are not equal");
        }
    }
}

