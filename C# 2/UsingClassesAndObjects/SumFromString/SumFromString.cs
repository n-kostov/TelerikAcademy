using System;

class SumFromString
{

    static int SumAStringIntegers(string str)
    {
        string[] values = str.Split(' ');
        int result = 0;
        for (int i = 0; i < values.Length; i++)
        {
            result += int.Parse(values[i]);
        }
        return result;
    }

    static void Main()
    {
        string str = "43 68 9 23 318";
        Console.WriteLine(SumAStringIntegers(str));
    }
}

