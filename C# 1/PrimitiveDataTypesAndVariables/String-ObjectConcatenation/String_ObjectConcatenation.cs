using System;

class String_ObjectConcatenation
{
    static void Main()
    {
        string first = "Hello";
        string second = "World";
        object result = first + " " + second;
        Console.WriteLine(result);
        string resultInString = (string) result;
        Console.WriteLine(resultInString);
    }
}

