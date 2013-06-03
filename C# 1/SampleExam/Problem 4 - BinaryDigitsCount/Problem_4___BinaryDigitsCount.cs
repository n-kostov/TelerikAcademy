using System;

class Problem_4___BinaryDigitsCount
{
    static void Main()
    {
        byte b = byte.Parse(Console.ReadLine());
        short n = short.Parse(Console.ReadLine());
        int[] counter = new int[n];
        for (int i = 0; i < n; i++)
        {
            uint number = uint.Parse(Console.ReadLine());
            uint mask = 1;
            int count = 0;
            int shifter = 0;
            while (mask << shifter <= number)
            {
                if ((mask << shifter & number) >>shifter == b)
                {
                    count++;
                }
                shifter++;
                if (shifter == 32)
                {
                    break;
                }
            }
            counter[i] = count;
        }
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(counter[i]);
        }
    }
}

