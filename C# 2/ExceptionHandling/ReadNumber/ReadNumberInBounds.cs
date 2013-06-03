using System;

class ReadNumberInBounds
{

    static int ReadNumber(int start, int end)
    {
        Console.Write("number = ");

        int num = int.Parse(Console.ReadLine());
        if (num >= end || num <= start)
        {
            throw new ArgumentOutOfRangeException("The number is not in correct bounds");
        }

        return num;
    }

    static void Main()
    {
        int[] array = new int[10];
        int start = 1;
        int end = 100;
        try
        {
            for (int i = 0; i < 10; i++)
            {
                array[i] = ReadNumber(start, end);
                start = array[i];
            }
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }
        catch (FormatException)
        {
            Console.WriteLine("You didn't enter an integer number!");
        }
        catch (OverflowException)
        {
            Console.WriteLine("You entered too big number for an integer");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("The number you entered is not between {0} and {1}", start, end);
        }
    }
}

