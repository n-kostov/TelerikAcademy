using System;

class ConvertNumberToText
{
    static void Digits(int digit)
    {
        switch (digit)
        {
            case 0:
                Console.Write("Zero");
                break;
            case 1:
                Console.Write("One");
                break;
            case 2:
                Console.Write("Two");
                break;
            case 3:
                Console.Write("Three");
                break;
            case 4:
                Console.Write("Four");
                break;
            case 5:
                Console.Write("Five");
                break;
            case 6:
                Console.Write("Six");
                break;
            case 7:
                Console.Write("Seven");
                break;
            case 8:
                Console.Write("Eight");
                break;
            case 9:
                Console.Write("Nine");
                break;
            case 11:
                Console.Write("Eleven");
                break;
            case 12:
                Console.Write("Twelve");
                break;
            case 13:
                Console.Write("Thirteen");
                break;
            case 14:
                Console.Write("Fourteen");
                break;
            case 15:
                Console.Write("Fifteen");
                break;
            case 16:
                Console.Write("Sixteen");
                break;
            case 17:
                Console.Write("Seventeen");
                break;
            case 18:
                Console.Write("Eighteen");
                break;
            case 19:
                Console.Write("Nineteen");
                break;
        }
    }

    static void Decimals(int digit)
    {
        switch (digit)
        {

            case 2:
                Console.Write("Twenty");
                break;
            case 3:
                Console.Write("Thirty");
                break;
            case 4:
                Console.Write("Fourty");
                break;
            case 5:
                Console.Write("Fifty");
                break;
            case 6:
                Console.Write("Sixty");
                break;
            case 7:
                Console.Write("Seventy");
                break;
            case 8:
                Console.Write("Eighty");
                break;
            case 9:
                Console.Write("Ninety");
                break;


        }
    }

    static void Main()
    {
        int number = int.Parse(Console.ReadLine());
        if (number > 99)
        {
            Digits(number / 100);
            Console.Write(" hundred");
            number %= 100;
            int secondDigit = number / 10;
            if (secondDigit > 1)
            {
                Console.Write(" ");
                Decimals(secondDigit);
                if (number % 10 != 0)
                {
                    Console.Write(" ");
                    Digits(number % 10);
                }
            } 
            else
            {
                if (number != 0)
                {
                    Console.Write(" and ");
                    Digits(number);
                }
            }
        }
        else
        {
            if (number > 9)
            {

                int secondDigit = number / 10;
                if (secondDigit > 1)
                {
                    Decimals(secondDigit);
                    if (number % 10 != 0)
                    {
                        Console.Write(" ");
                        Digits(number % 10);
                    }
                }
                else
                {
                    if (number > 9)
                    {
                        Digits(number);
                    }
                    else
                    {
                        Console.Write(" and ");
                        Digits(number);
                    }
                }
            }
            else
            {
                Digits(number);
            }
        }
        Console.WriteLine();
    }
}

