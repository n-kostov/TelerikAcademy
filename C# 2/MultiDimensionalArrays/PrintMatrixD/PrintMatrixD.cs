using System;

class PrintMatrixD
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int arrayLength = n;
        int[,] array = new int[n, n];
        int value = 1;
        int currentRow = 0;
        int currentColumn = 0;

        while (n > 0)
        {

            for (int i = 0; i < n; i++)
            {
                array[currentRow++, currentColumn] = value;
                value++;
            }
            currentColumn++; // start from the neighbor column
            currentRow--;
            n--;

            for (int i = 0; i < n; i++)
            {
                array[currentRow, currentColumn++] = value;
                value++;
            }
            currentRow--; // go to the last free column
            currentColumn--; // go to the last free row

            for (int i = 0; i < n; i++)
            {
                array[currentRow--, currentColumn] = value;
                value++;
            }
            currentRow++; //go to the first free row
            currentColumn--; // go to the neighbor column
            n--;

            for (int i = 0; i < n; i++)
            {
                array[currentRow, currentColumn--] = value;
                value++;
            }
            currentColumn++; // go to the first free column
            currentRow++; // go to the neighbor row



        }

        for (int i = 0; i < arrayLength; i++)
        {
            for (int j = 0; j < arrayLength; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

