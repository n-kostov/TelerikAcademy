using System;

class BinarySearch
{
    static void Main()
    {
        int[] array = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19, 21 };
        Console.Write("number = ");
        int number = int.Parse(Console.ReadLine());
        int start = 0;
        int end = array.Length - 1;
        bool found = false;
        int index = -1;
        while (start <= end)
        {

            int middle = (start + end) / 2;
            if (array[middle] < number)
            {
                start = middle + 1;
            } 
            else if(array[middle] > number)
            {
                end = middle - 1;
            }
            else
            {
                found = true;
                index = middle;
                break;
            }

        }

        if (found)
        {
            Console.WriteLine("Found {0} in index {1}!", number, index);
        } 
        else
        {
            Console.WriteLine("{0} not found", number);
        }
    }
}

