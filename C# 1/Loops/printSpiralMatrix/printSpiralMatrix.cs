using System;

class printSpiralMatrix
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
                array[currentRow,currentColumn + i] = value;
                value++;
            }
            currentRow = currentRow + n - 1; // go to the last free column
            currentColumn = currentColumn + n - 1; // go to the last free row
            n--;

            for (int i = 0; i < n; i++)
            {
                array[currentRow - (n - i - 1), currentColumn] = value;
                value++;
            }
            currentColumn--; // start from the neighbor column

            for (int i = 0; i < n; i++)
            {
                array[currentRow, currentColumn - i] = value;
                value++;
            }
            n--;
            currentColumn -= n; // go to the first free column
            currentRow--; // go to the neighbor row


            for (int i = 0; i < n; i++)
            {
                array[currentRow - i, currentColumn] = value;
                value++;
            }
            currentRow = currentRow - n + 1; //go to the first free row
            currentColumn++; // go to the neighbor column
        }

        for (int i = 0; i < arrayLength; i++ )
        {
            for (int j = 0; j < arrayLength; j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

