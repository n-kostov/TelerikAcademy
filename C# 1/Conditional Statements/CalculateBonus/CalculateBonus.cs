using System;

class CalculateBonus
{
    static void Main()
    {
        int digit = int.Parse(Console.ReadLine());
        int bonus = 0;
        bool flag = true;
        switch (digit)
        {
            case 1:
            case 2:
            case 3:
                bonus = digit * 10;
                break;
            case 4:
            case 5:
            case 6:
                bonus = digit * 100;
                break;
            case 7:
            case 8:
            case 9:
                bonus = digit * 100;
                break;
            default:
                Console.WriteLine("You didnt enter a digit ");
                flag = false;
                break;
        }

        if (flag)
        {
            Console.WriteLine("Your bonus is:{0}", bonus);
        }
    }
}

