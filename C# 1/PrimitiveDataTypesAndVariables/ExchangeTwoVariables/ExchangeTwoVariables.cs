using System;

class ExchangeTwoVariables
{
    static void Main()
    {
        int a = 5;
        int b = 10;
        Console.WriteLine("a = {0}\nb = {1}", a , b);
        int swap = a;
        a = b;
        b = swap;
        Console.WriteLine("After the exchange of values we have:\n"+
            "a = {0}\nb = {1}", a , b);
    }
}

