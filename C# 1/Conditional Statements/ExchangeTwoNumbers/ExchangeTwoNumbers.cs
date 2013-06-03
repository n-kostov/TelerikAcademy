using System;

class ExchangeTwoNumbers
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int swap = 0;
        Console.WriteLine("firstNumber={0}  secondNumber={1}", firstNumber, secondNumber);
        if (firstNumber > secondNumber)
        {
            swap = firstNumber;
            firstNumber = secondNumber;
            secondNumber = swap;
        }
        Console.WriteLine("After checking...");
        Console.WriteLine("firstNumber={0}  secondNumber={1}", firstNumber, secondNumber);
    }
}

