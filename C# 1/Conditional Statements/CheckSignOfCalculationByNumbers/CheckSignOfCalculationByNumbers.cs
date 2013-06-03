using System;

class CheckSignOfCalculationByNumbers
{
    static void Main()
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        double thirdNumber = double.Parse(Console.ReadLine());

        if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            Console.WriteLine("The calculation will be 0");
        } 
        else
        {
            if (firstNumber < 0)
            {
                if (secondNumber < 0)
                {
                    if (thirdNumber < 0)
                    {
                        Console.WriteLine("The sign of the calculation is -");
                    } 
                    else
                    {
                        Console.WriteLine("The sign of the calculation is +");
                    }
                } 
                else
                {
                    if (thirdNumber < 0)
                    {
                        Console.WriteLine("The sign of the calculation is +");
                    }
                    else
                    {
                        Console.WriteLine("The sign of the calculation is -");
                    }
                }
            } 
            else
            {
                if (secondNumber < 0)
                {
                    if (thirdNumber < 0)
                    {
                        Console.WriteLine("The sign of the calculation is +");
                    }
                    else
                    {
                        Console.WriteLine("The sign of the calculation is -");
                    }
                }
                else
                {
                    if (thirdNumber < 0)
                    {
                        Console.WriteLine("The sign of the calculation is -");
                    }
                    else
                    {
                        Console.WriteLine("The sign of the calculation is +");
                    }
                }
            }
        }
    }
}

