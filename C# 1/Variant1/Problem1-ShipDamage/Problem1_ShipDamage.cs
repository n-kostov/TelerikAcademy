using System;

class Problem1_ShipDamage
{
    static void Main()
    {
        int SX1 = int.Parse(Console.ReadLine());
        int SY1 = int.Parse(Console.ReadLine());
        int SX2 = int.Parse(Console.ReadLine());
        int SY2 = int.Parse(Console.ReadLine());
        int H = int.Parse(Console.ReadLine());
        int CX1 = int.Parse(Console.ReadLine());
        int CY1 = int.Parse(Console.ReadLine());
        int CX2 = int.Parse(Console.ReadLine());
        int CY2 = int.Parse(Console.ReadLine());
        int CX3 = int.Parse(Console.ReadLine());
        int CY3 = int.Parse(Console.ReadLine());

        int leftX;
        int downY;
        int width;
        int height;
        int damage = 0;
        if (SX1 < SX2)
        {
            leftX = SX1;
        }
        else
        {
            leftX = SX2;
        }
        if (SY1 < SY2)
        {
            downY = SY1;
        }
        else
        {
            downY = SY2;
        }
        height = Math.Abs(SY1 - SY2);
        width = Math.Abs(SX2 - SX1);

        int projectile;
        // first catapult
        if (H < CY1)
        {
            projectile = -(CY1 - H) * 2;
        }
        else
        {
            projectile = -(CY1 - H) * 2;
        }

        if ((CX1 == leftX && CY1 + projectile == downY) || (CX1 == leftX && CY1 + projectile == downY + height) ||
            (CX1 == leftX + width && CY1 + projectile == downY) || (CX1 == leftX +width && CY1 + projectile == downY + height))
        {
            damage += 25;
        } 
        else if ((CX1 == leftX && CY1 + projectile > downY && CY1 + projectile < downY + height) ||
            (CX1 == leftX + width && CY1 + projectile > downY && CY1 + projectile < downY + height) ||
            (CY1 + projectile == downY && CX1 >leftX && CX1 < leftX + width) ||
            (CY1 + projectile == downY + height && CX1 > leftX && CX1 < leftX + width))
        {
            damage += 50;
        }
        else if (CX1 < leftX || CX1 > leftX + width || CY1 + projectile < downY || CY1 + projectile > downY + height)
        {
            damage += 0;
        }
        else
        {
            damage += 100;
        }

        // second catapult
        if (H < CY2)
        {
            projectile = -(CY2 - H) * 2;
        }
        else
        {
            projectile = -(CY2 - H) * 2;
        }

        if ((CX2 == leftX && CY2 + projectile == downY) || (CX2 == leftX && CY2 + projectile == downY + height) ||
            (CX2 == leftX + width && CY2 + projectile == downY) || (CX2 == leftX + width && CY2 + projectile == downY + height))
        {
            damage += 25;
        }
        else if ((CX2 == leftX && CY2 + projectile > downY && CY2 + projectile < downY + height) ||
            (CX2 == leftX + width && CY2 + projectile > downY && CY2 + projectile < downY + height) ||
            (CY2 + projectile == downY && CX2 > leftX && CX2 < leftX + width) ||
            (CY2 + projectile == downY + height && CX2 > leftX && CX2 < leftX + width))
        {
            damage += 50;
        }
        else if (CX2 < leftX || CX2 > leftX + width || CY2 + projectile < downY || CY2 + projectile > downY + height)
        {
            damage += 0;
        }
        else
        {
            damage += 100;
        }

        // third catapult
        if (H < CY3)
        {
            projectile = -(CY3 - H) * 2;
        }
        else
        {
            projectile = -(CY3 - H) * 2;
        }

        if ((CX3 == leftX && CY3 + projectile == downY) || (CX3 == leftX && CY3 + projectile == downY + height) ||
            (CX3 == leftX + width && CY3 + projectile == downY) || (CX3 == leftX + width && CY3 + projectile == downY + height))
        {
            damage += 25;
        }
        else if ((CX3 == leftX && CY3 + projectile > downY && CY3 + projectile < downY + height) ||
            (CX3 == leftX + width && CY3 + projectile > downY && CY3 + projectile < downY + height) ||
            (CY3 + projectile == downY && CX3 > leftX && CX3 < leftX + width) ||
            (CY3 + projectile == downY + height && CX3 > leftX && CX3 < leftX + width))
        {
            damage += 50;
        }
        else if (CX3 < leftX || CX3 > leftX + width || CY3 + projectile < downY || CY3 + projectile > downY + height)
        {
            damage += 0;
        }
        else
        {
            damage += 100;
        }

        Console.WriteLine("{0}%", damage);
    }
}

