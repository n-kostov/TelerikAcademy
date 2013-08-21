using System;
using System.Collections.Generic;

namespace _10.AllAreasOfPassableCells
{
    public class Program
    {
        private const char FreeCell = ' ';
        private const char VisitedCell = 'x';
        private const char BlockedCell = '*';
        private const char Exit = 'e';
        private static List<Tuple<int, int>> currentPath;
        private static char[,] matrix = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', '*', ' ', ' ', '*', ' ', '*'},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
        };

        public static void FindPath(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == BlockedCell ||
                matrix[row, col] == VisitedCell)
            {
                return;
            }

            matrix[row, col] = VisitedCell;
            currentPath.Add(new Tuple<int, int>(row, col));

            FindPath(row, col - 1);
            FindPath(row - 1, col);
            FindPath(row, col + 1);
            FindPath(row + 1, col);
        }

        public static void Main(string[] args)
        {
            currentPath = new List<Tuple<int, int>>();
            int areaCounter = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == FreeCell)
                    {
                        FindPath(row, col);
                        Console.Write("Passable area {0}: ", areaCounter++);
                        Console.WriteLine(string.Join(", ", currentPath));
                        Console.WriteLine();
                        currentPath.Clear();
                    }
                }
            }
        }
    }
}
