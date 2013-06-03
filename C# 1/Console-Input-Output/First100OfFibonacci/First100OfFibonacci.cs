using System;
using System.Numerics;
class First100OfFibonacci
{
    static void Main()
    {
        
        BigInteger firstNumber = 0;
        BigInteger secondNUmber = 1;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine("{0}", firstNumber);
            secondNUmber += firstNumber;
            firstNumber = secondNUmber - firstNumber;

        }
    }
}

