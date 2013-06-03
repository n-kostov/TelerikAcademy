using System;

class NumbersBetween2Integers
{
    static void Main()
    {
        int firstNumber = 0;
        while (!int.TryParse(Console.ReadLine(), out firstNumber) || firstNumber <= 0) ;
        int secondNumber = 0;
        while (!int.TryParse(Console.ReadLine(), out secondNumber) || secondNumber <= 0) ;
        int p = firstNumber / 5 - secondNumber / 5;
        p = Math.Abs(p);
        int min = Math.Min(firstNumber, secondNumber);
        if (min % 5 == 0)
        {
            p++;
        }
        //if (secondNumber % 5 == 0)
        //{
        //    p++;
        //}
        Console.WriteLine(p);
    }
}

