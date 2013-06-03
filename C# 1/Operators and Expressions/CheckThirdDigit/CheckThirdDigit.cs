using System;

class CheckThirdDigit
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        bool isThirdDigit7 = ((number / 100) % 10) == 7;
        Console.WriteLine("{0} ==> {1}", number, isThirdDigit7);
    }
}

