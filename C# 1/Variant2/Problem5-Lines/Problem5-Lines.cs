using System;

class Problem5_Lines
{
    static void Main()
    {
        int[,] Array = new int[8, 8];
        // initialize the grid
        for (int i = 0; i < 8; i++)
        {
            byte number = byte.Parse(Console.ReadLine());
            byte delim = 128;
            for (int j = 0; j < 8; j++)
            {
                if (number >= delim)
                {
                    Array[i, j] = 1;
                    number -= delim;
                    delim /= 2;
                }
                else
                {
                    Array[i, j] = 0;
                    delim /= 2;
                }
            }
        }

        byte lenght = 0;
        byte count = 0;
        for (int i = 0; i < 8; i++)
        {
            byte currentLenght = 0;
            for (int j = 0; j < 8; j++)
            {
                if (Array[i, j] == 1)
                {
                    currentLenght++;
                    if (currentLenght > lenght)
                    {
                        lenght = currentLenght;
                        count = 0;
                    }
                    if (currentLenght == lenght)
                    {
                        count++;
                    }
                }
                else
                {
                    currentLenght = 0;
                }
            }
        }
        for (int i = 0; i < 8; i++)
        {
            byte currentLenght = 0;
            for (int j = 0; j < 8; j++)
            {
                if (Array[j, i] == 1)
                {

                    currentLenght++;
                    if (currentLenght > lenght)
                    {
                        lenght = currentLenght;
                        count = 0;
                    }
                    if (currentLenght == lenght)
                    {
                        count++;
                    }

                }
                else
                {
                    currentLenght = 0;
                }
            }
        }
        // if the line has lenght 1 we counted the it from one row and one column
        if (lenght == 1)
        {
            count /= 2;
        }

        Console.WriteLine(lenght);
        Console.WriteLine(count);
    }
}