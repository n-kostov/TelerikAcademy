using System;
using System.IO;

class SquareMatrix
{
    static void Main()
    {
        string fileName = "matrix.txt";
        StreamReader streamReader = new StreamReader(fileName);
        int length = int.Parse(streamReader.ReadLine());
        int[,] array = new int[length, length];
        for (int i = 0; i < array.GetLength(0); i++)
        {
            string[] line = streamReader.ReadLine().Split(' ');
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = int.Parse(line[j]);
            }
        }
        streamReader.Dispose();
        int bestSum = int.MinValue;
        for (int i = 0; i < array.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < array.GetLength(1) - 1; j++)
            {
                int currentSum = array[i, j] + array[i, j + 1] + array[i + 1, j] + array[i + 1, j + 1];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                }
            }
        }
        string resultFileName = "result.txt";
        StreamWriter streamWriter = new StreamWriter(resultFileName);
        streamWriter.Write(bestSum);
        streamWriter.Dispose();
    }
}

