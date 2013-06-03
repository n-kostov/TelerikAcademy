using System;

class AssignWithOrWithoutQuotedStrings
{
    static void Main()
    {
        string first = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine(first);
        first = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(first);
    }
}

