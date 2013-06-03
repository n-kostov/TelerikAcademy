using System;

class BiggestInteger
{

    static int GetMax(int x, int y)
    {
        if (x > y)
        {
            return x;
        } 
        else
        {
            return y;
        }
    }

    static void Main()
    {
        Console.Write("firstNumber = ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("secondNumber = ");
        int secondNumber = int.Parse(Console.ReadLine());
        Console.Write("thirdNumber = ");
        int thirdNumber = int.Parse(Console.ReadLine());

        Console.WriteLine("The biggest number is {0}", GetMax(firstNumber,GetMax(secondNumber,thirdNumber)));
    }
}

