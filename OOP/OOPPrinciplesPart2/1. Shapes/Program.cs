using System;

//  1.Define abstract class Shape with only one abstract method CalculateSurface() and fields width and height. 
//  Define two new classes Triangle and Rectangle that implement the virtual method and return the surface of the figure 
//  (height*width for rectangle and height*width/2 for triangle). Define class Circle and suitable constructor so that at
//  initialization height must be kept equal to width and implement the CalculateSurface() method. 
//  Write a program that tests the behavior of  the CalculateSurface() method for different shapes 
//  (Circle, Rectangle, Triangle) stored in an array.

class Program
{
    static void Main(string[] args)
    {
        Shape[] myShapes = { new Circle(2.5), new Rectangle(2, 3.5), new Triangle(3, 4) };
        foreach (var shape in myShapes)
        {
            Console.WriteLine("The area of the {0} is {1:f2}", shape.GetType(), shape.CalculateSurface());
        }
    }
}