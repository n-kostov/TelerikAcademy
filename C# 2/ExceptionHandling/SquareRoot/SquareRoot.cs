using System;

class SquareRoot
{

    static void Main()
    {
        Console.Write("number = ");
        int number;
        double result = 0;
        try
        {
            number = int.Parse(Console.ReadLine());
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid number");
            }
            result = Math.Sqrt(number);
            Console.WriteLine(result);
        }
        catch (ArgumentOutOfRangeException aore)
        {
            Console.Error.WriteLine("Invalid number!", aore);
        }
        catch (FormatException fe)
        {
            Console.Error.WriteLine("Invalid number!", fe);
        }
        catch (OverflowException oe)
        {
            Console.Error.WriteLine("Invalid number!", oe);
        }
        finally
        {
            Console.WriteLine("Good bye");
        }

    }
}