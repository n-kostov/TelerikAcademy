using System;

class BiggestOfThree
{
    static void Main()
    {
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        Console.Write("The biggest of them is:");
        if (a > b)
        {
            if (a > c)
            {
                Console.WriteLine(a);
            } 
            else
            {
                Console.WriteLine(c);
            }
        } 
        else
        {
            if (b > c)
            {
                Console.WriteLine(b);
            } 
            else
            {
                Console.WriteLine(c);
            }
        }
    }
}

