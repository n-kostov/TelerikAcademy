//  1. Take the VS solution "Abstraction" and refactor its code to provide good abstraction. 
//  Move the properties and methods from the class Figure to their correct place. 
//  Move the common methods to the base class's interface. 
//  Remove all duplicated code (properties / methods / other code).
//
//  2. Establish good encapsulation in the classes from the VS solution "Abstraction". 
//  Ensure that incorrect values cannot be assigned in the internal state of the classes.

namespace Abstraction
{
    using System;

    public class FiguresExample
    {
        public static void Main()
        {
            Figure circle = new Circle(5);
            Console.WriteLine("I am a circle. " + "My perimeter is {0:f2}. My surface is {1:f2}.", circle.CalcPerimeter(),                              circle.CalcSurface());

            Figure rect = new Rectangle(2, 3);
            Console.WriteLine("I am a rectangle. " + "My perimeter is {0:f2}. My surface is {1:f2}.", rect.CalcPerimeter(),                             rect.CalcSurface());
        }
    }
}
