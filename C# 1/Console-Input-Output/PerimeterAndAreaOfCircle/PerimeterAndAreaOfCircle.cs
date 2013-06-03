using System;

class PerimeterAndAreaOfCircle
{
    static void Main()
    {
        float r = 0;
        while (!float.TryParse(Console.ReadLine(), out r)) ;
        Console.WriteLine("The perimeter of the circle is {0}", 2*r*Math.PI);
    }
}

