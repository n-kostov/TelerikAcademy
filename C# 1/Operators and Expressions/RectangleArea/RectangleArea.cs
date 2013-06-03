using System;

class RectangleArea
{
    static void Main()
    {
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        int area = width * height;
        Console.WriteLine("The area of the rectangle is:{0}", area);
    }
}

