using System;

internal class RefactorLoop
{
    public static void Main(string[] args)
    {
        bool expectedValueFound = false;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(array[i]);
            if (i % 10 == 0)
            {
                if (array[i] == expectedValue)
                {
                    expectedValueFound = true;
                    break;
                }
            }
        }

        // More code here
        if (expectedValueFound)
        {
            Console.WriteLine("Value Found");
        }
    }
}