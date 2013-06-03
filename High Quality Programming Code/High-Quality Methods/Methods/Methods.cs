using System.Globalization;
using System;
using System.Threading;

namespace Methods
{
    class Methods
    {
        static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Sides should be positive!");
            }

            if (!FormTriangle(a, b, c))
            {
                throw new ArgumentException("In triangle the sum of any two sides cannot be bigger than the third side!");
            }

            double halfArea = (a + b + c) / 2;
            double area = Math.Sqrt(halfArea * (halfArea - a) * (halfArea - b) * (halfArea - c));
            return area;
        }

        static bool FormTriangle(double a, double b, double c)
        {
            return a + b > c && b + c > a && a + c > b;
        }

        static string DigitToText(int digit)
        {
            switch (digit)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default: throw new ArgumentOutOfRangeException("The digit cannot be out of range [0..9]!");
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("The input cannot be null!");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("The input array must have at least one element!");
            }

            int max = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    max = elements[i];
                }
            }

            return max;
        }

        static void PrintNumber(double number, int decimalPoints)
        {
            string format = "{0:F" + decimalPoints + "}";

            Console.WriteLine(format, number);
        }

        static void PrintPercent(double number, int decimalPoints)
        {
            string format = "{0:P" + decimalPoints + "}";

            Console.WriteLine(format, number);
        }

        static void PrintAligned(object value, int width)
        {
            string format = "{0, " + width + "}";

            Console.WriteLine(format, value);
        }


        static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));

            return distance;
        }

        static bool IsLineHorizontal(double x1, double y1, double x2, double y2)
        {
            bool isHorizontal = (y1 == y2);

            return isHorizontal;
        }

        static bool IsLineVertical(double x1, double y1, double x2, double y2)
        {
            bool isVertical = (x1 == x2);

            return isVertical;
        }

        static void Main()
        {
            Thread.CurrentThread.CurrentCulture  = CultureInfo.InvariantCulture;

            Console.WriteLine(CalculateTriangleArea(3, 4, 5));
            
            Console.WriteLine(DigitToText(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintNumber(1.3, 2);
            PrintPercent(0.75, 3);
            PrintAligned(2.30, 5);

            bool horizontal = IsLineHorizontal(3, -1, 3, 2.5);
            bool vertical = IsLineVertical(3, -1, 3, 2.5);
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov" };
            peter.Birthdate = new DateTime(1992, 3, 17);

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova" };
            stella.Birthdate = new DateTime(1993, 11, 3);

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
