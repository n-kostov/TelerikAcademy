using System;

class SortThreeNumbersDescending
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        Console.WriteLine("Lets sort em");
        if (a > b)
        {
            if (a > c)
            {
                Console.WriteLine(a);
                if (b > c)
                {
                    Console.WriteLine(b);
                    Console.WriteLine(c);
                } 
                else
                {
                    Console.WriteLine(c);
                    Console.WriteLine(b);
                }
            }
            else
            {
                Console.WriteLine(c);
                Console.WriteLine(a);
                Console.WriteLine(b);
            }
        }
        else
        {
            if (b > c)
            {
                Console.WriteLine(b);
                if (a > c)
                {
                    Console.WriteLine(a);
                    Console.WriteLine(c);
                }
                else
                {
                    Console.WriteLine(c);
                    Console.WriteLine(a);
                }
            }
            else
            {
                Console.WriteLine(c);
                Console.WriteLine(b);
                Console.WriteLine(a);
            }
        }
    }
}

