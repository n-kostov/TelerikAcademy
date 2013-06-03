using System;

class QuickSort
{
    static void Quick(string[] arr, int left, int right)
    {

        int i = left, j = right;
        string tmp;
        string pivot = arr[(left + right) / 2];
        while (i <= j)
        {

            while (string.Compare(arr[i], pivot) < 0)
            {
                i++;
            }
            while (string.Compare(arr[j], pivot) > 0)
            {
                j--;
            }
            if (i <= j)
            {
                tmp = arr[i];
                arr[i] = arr[j];
                arr[j] = tmp;
                i++;
                j--;
            }

        }

        if (left < j)
        {
            Quick(arr, left, j);
        }
        if (i < right)
        {
            Quick(arr, i, right);
        }
    }

    static void Main()
    {
        string[] array = { "zebra", "horse", "apple", "rebel" };
        Quick(array, 0, array.Length - 1);
        foreach (string item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

