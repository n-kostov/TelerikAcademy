namespace _2.PointInTriangle
{
    using System;

    public class Program
    {
        // see http://en.wikipedia.org/wiki/Barycentric_coordinate_system
        public static void Main(string[] args)
        {
            Console.Write("x1 = ");
            var x1 = double.Parse(Console.ReadLine());
            Console.Write("y1 = ");
            var y1 = double.Parse(Console.ReadLine());
            Console.Write("x2 = ");
            var x2 = double.Parse(Console.ReadLine());
            Console.Write("y2 = ");
            var y2 = double.Parse(Console.ReadLine());
            Console.Write("x3 = ");
            var x3 = double.Parse(Console.ReadLine());
            Console.Write("y3 = ");
            var y3 = double.Parse(Console.ReadLine());

            Console.Write("x4 = ");
            var x4 = double.Parse(Console.ReadLine());
            Console.Write("y4 = ");
            var y4 = double.Parse(Console.ReadLine());

            double dx = x4 - x3;
            double dy = y4 - y3;

            double a = x1 - x3;
            double b = y1 - y3;
            double c = x2 - x3;
            double d = y2 - y3;

            double denom = (a * d) - (b * c);

            double alpha = (d * dx) - (c * dy);
            alpha /= denom;

            double beta = (-b * dx) + (a * dy);
            beta /= denom;

            double gamma = 1.0 - (alpha + beta);

            if (alpha >= 0 && beta >= 0 && gamma >= 0)
            {
                Console.WriteLine("Point lies inside the triangle.");
            }
            else
            {
                Console.WriteLine("Point lies outside the triangle.");
            }
        }
    }
}
