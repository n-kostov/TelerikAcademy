using System;
using System.IO;

class NumberOfEqualLines
{
    static void Main()
    {
        string fileName1 = "file1.txt";
        string fileName2 = "file2.txt";
        StreamReader streamReader1 = new StreamReader(fileName1);
        StreamReader streamReader2 = new StreamReader(fileName2);
        int same = 0;
        int different = 0;
        while (!streamReader1.EndOfStream && !streamReader2.EndOfStream)
        {
            if (streamReader1.ReadLine() == streamReader2.ReadLine())
            {
                same++;
            } 
            else
            {
                different++;
            }
        }
        streamReader1.Dispose();
        streamReader2.Dispose();
        Console.WriteLine("The number of same lines is {0}", same);
        Console.WriteLine("The number of different lines is {0}", different);
    }
}

