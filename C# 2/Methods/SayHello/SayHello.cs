using System;

class SayHello
{

    static void Greet()
    {
        Console.Write("Your name is:");
        string name = Console.ReadLine();
        Console.WriteLine("Hello, {0}!", name);
    }

    static void Main()
    {
        Greet();
    }
}

