using System;

class CompareFloating_PointNumbers
{
    static void Main()
    {
        double first = 5.3;
        double second = 6.01f;
        bool result = Math.Abs(first - second) < 0.000001f;
        Console.WriteLine("{0} == {1}? ==>{2}", first , second , result);

        first = 5.00000001;
        second = 5.00000003;
        result = Math.Abs(first - second) <= 0.000001f;
        Console.WriteLine("{0} == {1}? ==>{2}", first, second, result);
    }
}

