using System;

class TaskMenu
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

    static float Average(int[] array)
    {
        float average = 0;
        for (int i = 0; i < array.Length; i++)
        {
            average += array[i];
        }
        return average / array.Length;
    }

    static float SolveLinearEquation(int a, int b)
    {
        float x = -b / (float)a;
        return x;
    }

    static void Main()
    {
        Console.WriteLine("Hello, user");
        Console.WriteLine("Choose:");
        Console.WriteLine("1. Reverse a digit");
        Console.WriteLine("2. Calculate Average of integer sequence");
        Console.WriteLine("3. Solve linear equation ");
        int choice = int.Parse(Console.ReadLine());
        int n;
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter a non-negative nummber = ");
                n = -1;
                while (n < 0)
                {
                    n = int.Parse(Console.ReadLine());
                }
                Console.WriteLine(Reverse(n));
                break;
            case 2:
                Console.WriteLine("How long do you want the sequence to be = ");
                n = 0;
                while (n <= 0)
                {
                    n = int.Parse(Console.ReadLine());
                }
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Average of this sequence is {0}", Average(array));
                break;
            case 3:
                Console.WriteLine("Enter non zero a = ");
                int a = 0;
                while (a == 0)
                {
                    a = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("Enter b = ");
                int b = int.Parse(Console.ReadLine());
                Console.WriteLine("For {0}*x + {1} = 0  x = {2}", a, b, SolveLinearEquation(a, b));
                break;
            default:
                Console.WriteLine("You no follow the rules");
                break;
        }
    }
}

