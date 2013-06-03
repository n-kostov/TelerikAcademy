using System;

class Problem3_ForestRoad
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        byte heigth =(byte) (2 * n - 1);
        bool right = true;
        byte currentPosition = 0;
        for (int i = 0; i < heigth; i++)
        {
            char[] str = new char[n];
            for (int j = 0; j < n; j++)
            {
                str[j] = '.';
            }
            str[currentPosition] = '*';
            Console.WriteLine(str);
            if (right)
            {
                currentPosition++;
            } 
            else
            {
                currentPosition--;
            }
            if (currentPosition == n - 1)
            {
                right = false;
            }
            if (currentPosition == 0)
            {
                right = true;
            }
        }
    }
}

