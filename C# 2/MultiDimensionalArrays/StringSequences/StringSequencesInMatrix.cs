using System;

class StringSequencesInMatrix
{
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine());
        string[,] array = new string[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("array[{0},{1}] = ", i, j);
                array[i, j] = Console.ReadLine();
            }
        }
        string word = array[0, 0];
        int bestCount = 1;

        // horizontally
        for (int row = 0; row < n; row++)
        {
            for (int i = 0; i < m - 1; i++)
            {
                int count = 1;
                for (int j = i + 1; j < m; j++)
                {
                    if (array[row, i] == array[row, j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    if (count > bestCount)
                    {
                        bestCount = count;
                        word = array[row, i];
                    }
                }
            }
        }

        // vertically
        for (int col = 0; col < m; col++)
        {
            for (int i = 0; i < n - 1; i++)
            {
                int count = 1;
                for (int j = i + 1; j < n; j++)
                {
                    if (array[i, col] == array[j, col])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    if (count > bestCount)
                    {
                        bestCount = count;
                        word = array[i, col];
                    }
                }
            }
        }

        // diagonally first diagonal
        for (int row = 0; row < n - 1; row++)
        {
            for (int i = 0; i < n - 1 && i < m - 1; i++)
            {
                int count = 1;
                for (int j = i + 1; j < m && j < n; j++)
                {
                    if (array[row, i] == array[row - i + j, j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    if (count > bestCount)
                    {
                        bestCount = count;
                        word = array[row, i];
                    }
                }
                if (row != 0)
                {
                    break;
                }
            }
        }

        // diagonally second diagonal
        for (int row = 0; row < n - 1; row++)
        {
            for (int i = m - 1; i > 0 && i > Math.Abs(n-m); i--)
            {
                int count = 1;
                for (int j = i - 1; j >= 0 && j >= Math.Abs(n-m); j--)
                {
                    if (array[row, i] == array[row + i - j, j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    if (count > bestCount)
                    {
                        bestCount = count;
                        word = array[row, i];
                    }
                }
                if (row != 0)
                {
                    break;
                }
            }
        }

        Console.WriteLine("\"{0}\" - {1} times", word, bestCount);
    }
}

