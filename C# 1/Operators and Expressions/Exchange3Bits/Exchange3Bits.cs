using System;

class Exchange3Bits
{
    static void Main()
    {
        uint third;
        uint fourth;
        uint fifth;
        uint twenty_fourth;
        uint twenty_fifth;
        uint twenty_sixth;

        uint number = uint.Parse(Console.ReadLine());

        uint mask = 1;
        mask = mask << 3;
        mask = mask & number;
        mask = mask >> 3;
        third = mask;

        mask = 1;
        mask = mask << 4;
        mask = mask & number;
        mask = mask >> 4;
        fourth = mask;

        mask = 1;
        mask = mask << 5;
        mask = mask & number;
        mask = mask >> 5;
        fifth = mask;

        mask = 1;
        mask = mask << 24;
        mask = mask & number;
        mask = mask >> 24;
        twenty_fourth = mask;

        mask = 1;
        mask = mask << 25;
        mask = mask & number;
        mask = mask >> 25;
        twenty_fifth = mask;

        mask = 1;
        mask = mask << 26;
        mask = mask & number;
        mask = mask >> 26;
        twenty_sixth = mask;

        mask = 1;
        mask = mask << 3;

        if (twenty_fourth == 1)
        {
            number = mask | number;
        }
        else
        {
            mask = ~mask;
            number = mask & number;
        }

        mask = 1;
        mask = mask << 24;

        if (third == 1)
        {
            number = mask | number;
        }
        else
        {
            mask = ~mask;
            number = mask & number;
        }


        mask = 1;
        mask = mask << 4;

        if (twenty_fifth == 1)
        {
            number = mask | number;
        }
        else
        {
            mask = ~mask;
            number = mask & number;
        }

        mask = 1;
        mask = mask << 25;

        if (fourth == 1)
        {
            number = mask | number;
        }
        else
        {
            mask = ~mask;
            number = mask & number;
        }


        mask = 1;
        mask = mask << 5;

        if (twenty_sixth == 1)
        {
            number = mask | number;
        }
        else
        {
            mask = ~mask;
            number = mask & number;
        }

        mask = 1;
        mask = mask << 26;

        if (fifth == 1)
        {
            number = mask | number;
        }
        else
        {
            mask = ~mask;
            number = mask & number;
        }

        Console.WriteLine(number);
    }
}

