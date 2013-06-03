using System;

class SumOf3Integers
{
    static void Main()
    {
        int firstNumber = 0;
        while(!int.TryParse(Console.ReadLine (), out firstNumber));
        int secondNumber = 0;
        while (!int.TryParse(Console.ReadLine(), out secondNumber)) ;
        int thirdNumber = 0;
        while (!int.TryParse(Console.ReadLine(), out thirdNumber)) ;
        Console.WriteLine("{0} + {1} + {2} = {3}", firstNumber, secondNumber, thirdNumber,
            firstNumber + secondNumber + thirdNumber);
    }
}

