namespace RotatingWalkInMatrix
{
    using System;

    public class RotatingWalkInMatrix
    {
        public static int ReadInput(int maxSize)
        {
            string input;
            int size;

            do
            {
                Console.WriteLine("Enter n, the size of the matrix 0 < n <= {0}:", maxSize);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out size) || size < 1 || size > maxSize);

            return size;
        }

        public static void Main(string[] args)
        {
            int size = ReadInput(15);
            Matrix matrix = new Matrix(size);
            Console.WriteLine(matrix);
        }
    }
}