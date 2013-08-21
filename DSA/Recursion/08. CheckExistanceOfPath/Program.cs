using System;

namespace _08.CheckExistanceOfPath
{
    public class Program
    {
        private const char FreeCell = ' ';
        private const char VisitedCell = 'x';
        private const char BlockedCell = '*';
        private const char Exit = 'e';
        private static char[,] labyrinth = 
        {
            {' ', ' ', ' ', '*', ' ', ' ', ' '},
            {'*', '*', ' ', '*', ' ', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', ' '},
            {' ', '*', '*', '*', '*', '*', ' '},
            {' ', ' ', ' ', ' ', ' ', ' ', 'e'},
        };

        private static char[,] matrix;

        public static bool HasPath(int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            if (matrix[row, col] == Exit)
            {
                return true;
            }

            if (matrix[row, col] == BlockedCell ||
                matrix[row, col] == VisitedCell)
            {
                return false;
            }

            matrix[row, col] = VisitedCell;

            bool pathExist = false;

            pathExist = pathExist || HasPath(row, col - 1);
            if (!pathExist)
            {
                pathExist = pathExist || HasPath(row - 1, col);
            }

            if (!pathExist)
            {
                pathExist = pathExist || HasPath(row, col + 1);
            }

            if (!pathExist)
            {
                pathExist = pathExist || HasPath(row + 1, col);
            }

            matrix[row, col] = FreeCell;
            return pathExist;
        }

        public static void Main(string[] args)
        {
            matrix = new char[100, 100];
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    matrix[i, j] = ' ';
                }
            }

            matrix[99, 99] = 'e';
            Console.WriteLine(HasPath(0, 0));
        }
    }
}
