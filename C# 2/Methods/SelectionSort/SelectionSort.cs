using System;

class SelectionSort
{

    static int FindMaxElementFrom(int index, out int k, int[] array)
    {
        int max = array[index];
        k = index;
        for (int i = index + 1; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
                k = i;
            }
        }
        return max;
    }

    static void Sort(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int k;
            int max = FindMaxElementFrom(i, out k, array);
            int swap = array[i];
            array[i] = max;
            array[k] = swap;
        }
    }

    static void Main()
    {
        int[] array = { 2, 6, 1, 8, 1 };
        Sort(array);
    }
}

