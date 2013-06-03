using System;

class Problem1_FighterAttack
{
    static void Main()
    {
        int p_x1 = int.Parse(Console.ReadLine());
        int p_y1 = int.Parse(Console.ReadLine());
        int p_x2 = int.Parse(Console.ReadLine());
        int p_y2 = int.Parse(Console.ReadLine());
        int f_x1 = int.Parse(Console.ReadLine());
        int f_y1 = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());

        int damage = 0;

        int height = Math.Abs(p_y1 - p_y2);
        int width = Math.Abs(p_x1 - p_x2);
        int down = Math.Min(p_y1, p_y2);
        int left = Math.Min(p_x1, p_x2);

        if (f_y1 >= down && f_y1 <= down + height && f_x1 + d >= left && f_x1 + d <= left + width)
        {
            damage += 100;
        }
        if (f_y1 + 1 >= down && f_y1 + 1 <= down + height && f_x1 + d >= left && f_x1 + d <= left + width)
        {
            damage += 50;
        }
        if (f_y1 - 1 >= down && f_y1 - 1 <= down + height && f_x1 + d >= left && f_x1 + d <= left + width)
        {
            damage += 50;
        }
        if (f_y1 >= down && f_y1 <= down + height && f_x1 + d + 1 >= left && f_x1 + d + 1 <= left + width)
        {
            damage += 75;
        }
        Console.WriteLine("{0}%", damage);
    }
}