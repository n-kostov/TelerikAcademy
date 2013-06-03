//This program finds greater of two numbers without using if-statements

using System;

class PrintGreaterInteger
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int max = (Math.Abs(a + b) + Math.Abs(a - b)) / 2;
        Console.WriteLine("The greatest of {0} and {1} is {2}", a , b , max);
    }
}

