using System;

class PrintASCII
{
    static void Main()
    {
        char @char = (char) 0;
        for (int i = 0; i < 256; i++)
        {
            Console.WriteLine("{0}: {1}", i ,@char++);
        }
    }
}

