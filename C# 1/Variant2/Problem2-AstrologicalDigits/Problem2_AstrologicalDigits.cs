using System;

class Problem2_AstrologicalDigits
{
    static void Main()
    {
        string n = Console.ReadLine();
        int sum = 0;
        for (int i = 0; i < n.Length; i++)
        {
            if (n[i] >= '0' && n[i] <= '9')
            {
                sum += n[i] - '0';
            }
        }
        while (sum > 9)
        {
            int s = 0;
            while (sum > 0)
            {
                s += sum % 10;
                sum /= 10;
            }
            sum = s;
        }
        Console.WriteLine(sum);
    }
}

