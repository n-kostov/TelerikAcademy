using System;

class ReverseDigitsOfNumber
{

    static int Reverse(int number)
    {
        int result = 0;
        int copyOfTheNumber = number;
        int power = 0;
        while (copyOfTheNumber > 9)
        {
            power++;
            copyOfTheNumber /= 10;
        }
        while (number > 0)
        {
            result += number % 10 * (int)Math.Pow(10, power);
            power--;
            number /= 10;
        }
        return result;
    }

    static void Main()
    {
        Console.WriteLine(Reverse(4532));
    }
}

