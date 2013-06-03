using System;

    class LargestNumberInArraySmallerThanK
    {
        static void Main()
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("k = ");
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write("array[{0}] = ", i);
                array[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(array);

            int numberSmallerThanK = 0;
            if (Array.BinarySearch(array, k) >= 0)
            {
                numberSmallerThanK = Math.Abs(Array.BinarySearch(array, k));
            } 
            else
            {
               numberSmallerThanK = Math.Abs(Array.BinarySearch(array, k)) - 2;
            }

            if (numberSmallerThanK >= 0)
            {
                Console.WriteLine(array[numberSmallerThanK]);
            } 
            else
            {
                Console.WriteLine("There is no such element in the array");
            }
        }
    }

