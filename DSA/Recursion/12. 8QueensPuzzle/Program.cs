using System;

namespace _12._8QueensPuzzle
{
    public class Program
    {
        private static char[,] matrix;
        private static char[,] used;
        private static int solutionsCounter = 0;

        public static void FindSolution(int queenNumber)
        {
            if (queenNumber >= 8)
            {
                PrintMatrix();
                solutionsCounter++;
                return;
            }

            // every queen could be on only one row on the chess field
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (used[queenNumber, col] == '0')
                {
                    matrix[queenNumber, col] = 'Q';
                    used[queenNumber, col]++;
                    BeatVertical(queenNumber, col, true);
                    BeatHorizontal(queenNumber, col, true);
                    BeatDiagonals(queenNumber, col, true);
                    FindSolution(queenNumber + 1);
                    matrix[queenNumber, col] = 'x';
                    used[queenNumber, col]--;
                    BeatVertical(queenNumber, col, false);
                    BeatHorizontal(queenNumber, col, false);
                    BeatDiagonals(queenNumber, col, false);
                }
            }
        }

        private static void BeatHorizontal(int row, int col, bool beat)
        {
            for (int i = 0; i < used.GetLength(1); i++)
            {
                if (i != col)
                {
                    if (beat)
                    {
                        used[row, i]++;
                    }
                    else
                    {
                        used[row, i]--;
                    }
                }
            }
        }

        private static void BeatVertical(int row, int col, bool beat)
        {
            for (int i = 0; i < used.GetLength(0); i++)
            {
                if (i != row)
                {
                    if (beat)
                    {
                        used[i, col]++;
                    }
                    else
                    {
                        used[i, col]--;
                    }
                }
            }
        }

        private static void BeatDiagonals(int row, int col, bool beat)
        {
            int i = row - 1;
            int j = col - 1;
            while (i >= 0 && j >= 0)
            {
                if (beat)
                {
                    used[i, j]++;
                }
                else
                {
                    used[i, j]--;
                }

                i--;
                j--;
            }

            i = row + 1;
            j = col - 1;
            while (i < used.GetLength(0) && j >= 0)
            {
                if (beat)
                {
                    used[i, j]++;
                }
                else
                {
                    used[i, j]--;
                }

                i++;
                j--;
            }

            i = row - 1;
            j = col + 1;
            while (i >= 0 && j < used.GetLength(1))
            {
                if (beat)
                {
                    used[i, j]++;
                }
                else
                {
                    used[i, j]--;
                }

                i--;
                j++;
            }

            i = row + 1;
            j = col + 1;
            while (i < used.GetLength(0) && j < used.GetLength(1))
            {
                if (beat)
                {
                    used[i, j]++;
                }
                else
                {
                    used[i, j]--;
                }

                i++;
                j++;
            }
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static void Main(string[] args)
        {
            matrix = new char[8, 8];
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 'x';
                }
            }

            used = new char[8, 8];
            for (int row = 0; row < used.GetLength(0); row++)
            {
                for (int col = 0; col < used.GetLength(1); col++)
                {
                    used[row, col] = '0';
                }
            }

            FindSolution(0);
            Console.WriteLine("The number of different solutions is {0}", solutionsCounter);
        }
    }
}
