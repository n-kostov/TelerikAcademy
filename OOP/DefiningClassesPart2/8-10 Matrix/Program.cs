using System;

namespace _8_10_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix<int> matrix = new Matrix<int>(3, 2);
            matrix[0, 0] = 1;
            matrix[0, 1] = 3;
            matrix[1, 0] = 0;
            matrix[1, 1] = -2;
            matrix[2, 0] = 4;
            matrix[2, 1] = 1;

            Matrix<int> mat = new Matrix<int>(2, 2);
            mat[0, 0] = 7;
            mat[0, 1] = 9;
            mat[1, 0] = 5;
            mat[1, 1] = 2;

            Matrix<int> result = matrix * mat;
            for (int i = 0; i < result.Row; i++)
            {
                for (int j = 0; j < result.Col; j++)
                {
                    Console.Write(result[i, j] + " ");
                }
                Console.WriteLine();
            }

            if (mat)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
        }
    }
}
