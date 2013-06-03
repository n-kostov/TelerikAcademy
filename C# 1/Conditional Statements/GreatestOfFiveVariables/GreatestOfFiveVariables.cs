using System;

class GreatestOfFiveVariables
{
    static void Main()
    {
        int firstNumber = int.Parse(Console.ReadLine());
        int secondNumber = int.Parse(Console.ReadLine());
        int thirdNumber = int.Parse(Console.ReadLine());
        int fourthNumber = int.Parse(Console.ReadLine());
        int fifthNumber = int.Parse(Console.ReadLine());
        int max = firstNumber;
        if ( max < secondNumber)
        {
            max = secondNumber;
        }
        if (max < thirdNumber)
        {
            max = thirdNumber;
        }
        if (max < fourthNumber)
        {
            max = fourthNumber;
        }
        if (max < fifthNumber)
        {
            max = fifthNumber;
        }
        Console.WriteLine("The biggest of em all is:{0}", max);
    }
}

