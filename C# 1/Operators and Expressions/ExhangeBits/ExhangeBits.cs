using System;

class ExhangeBits
{
    static void Main()
    {
        uint number = uint.Parse(Console.ReadLine());
        int p = int.Parse(Console.ReadLine());
        int q = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        uint[] p_s = new uint[k];
        uint[] q_s = new uint[k];

        uint mask = 1;
        for (int i = 0; i < k; i++)
        {
            mask = 1;
            mask = mask << (p+i);
            mask = mask & number;
            mask = mask >> (p+i);
            p_s[i] = mask;

            mask = 1;
            mask = mask << (q + i);
            mask = mask & number;
            mask = mask >> (q + i);
            q_s[i] = mask;
        }


        
        for(int i = 0;i<k;i++)
        {

        
            mask = 1;
            mask = mask << (p+i);

            if (q_s[i] == 1)
            {
                number = mask | number;
            }
            else
            {
                mask = ~mask;
                number = mask & number;
            }

            mask = 1;
            mask = mask << (q+i);

            if (p_s[i] == 1)
            {
                number = mask | number;
            }
            else
            {
                mask = ~mask;
                number = mask & number;
            }
        }
        Console.WriteLine(number);
    }
}

