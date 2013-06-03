using System;

class RandomNumbers
{
    static void Main()
    {
        Random rnd = new Random();
        for (int i = 0; i < 10; i++)
        {
            //int number = 100 + rnd.Next(101);
            int number = rnd.Next(100, 201);
            Console.WriteLine(number);
        }
    }
}

