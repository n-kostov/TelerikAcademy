using System;

class FirstElementBiggerThanHisNeighbors
{

    static bool BiggerThanNeighbors(int position, int[] array)
    {
        if (position < 0 || position >= array.Length)
        {
            return false;
        }
        else
        {
            if (position == 0)
            {
                return array[position] > array[position + 1];
            }
            else if (position == array.Length - 1)
            {
                return array[position] > array[position - 1];
            }
            else
            {
                return array[position] > array[position + 1] && array[position] > array[position] - 1;
            }
        }
    }

    static int FindFirstElementBiggerThanHisNeighbors(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (BiggerThanNeighbors(i,array))
            {
                return i;
            }
        }
        return -1;
    }

    static void Main()
    {
        int[] array = { 1, 2, 2 };
        Console.WriteLine(FindFirstElementBiggerThanHisNeighbors(array));
    }
}

