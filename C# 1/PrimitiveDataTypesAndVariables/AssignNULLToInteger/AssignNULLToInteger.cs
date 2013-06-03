using System;

class AssignNULLToInteger
{
    static void Main()
    {
        int? first = null;
        double? second = null;
        Console.WriteLine("{0}{1}Null values do nothing in the console", first , second);
        first = 5;
        second = 10;
        Console.WriteLine("{0} {1}", first , second);
        Console.WriteLine("Add null to int = {0}", first + null);
        Console.WriteLine("Add null to double = {0}", second + null);
    }
}

