using System;
using System.Collections.Generic;

namespace _07.AllPathsInMatrix
{
    public class Program
    {
        private const char FreeCell = ' ';
        private const char VisitedCell = 'x';
        private const char BlockedCell = '*';
        private const char Exit = 'e';
        private static List<Tuple<int, int>> path;
        private static int pathCounter = 1;
        private static char[,] matrix = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        public static void FindPaths(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return;
            }

            if (matrix[row, col] == Exit)
            {
                Console.Write("Path {0}: ", pathCounter++);
                path.Add(new Tuple<int, int>(row, col));
                Console.WriteLine(string.Join(", ", path));
                path.RemoveAt(path.Count - 1);
                Console.WriteLine();
                return;
            }

            if (matrix[row, col] == BlockedCell ||
                matrix[row, col] == VisitedCell)
            {
                return;
            }

            matrix[row, col] = VisitedCell;
            path.Add(new Tuple<int, int>(row, col));

            FindPaths(row, col - 1);
            FindPaths(row - 1, col);
            FindPaths(row, col + 1);
            FindPaths(row + 1, col);

            path.RemoveAt(path.Count - 1);
            matrix[row, col] = FreeCell;
        }

        public static void Main(string[] args)
        {
            path = new List<Tuple<int, int>>();
            FindPaths(0, 0);
        }
    }
}
