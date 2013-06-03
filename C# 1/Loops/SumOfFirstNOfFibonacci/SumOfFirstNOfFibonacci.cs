using System;

class SumOfFirstNOfFibonacci
{
    static void Main()
    {
        int sum = 0;
        int n = int.Parse(Console.ReadLine());
        int firstNumber = 0;
        int secondNumber = 1;
        if (n > 1)
        {
            sum += firstNumber + secondNumber;
        }
        for (int i = 2; i < n; i++)
        {
            secondNumber += firstNumber;
            firstNumber = secondNumber - firstNumber;
            sum += secondNumber;
        }
        Console.WriteLine(sum);

    }
}

