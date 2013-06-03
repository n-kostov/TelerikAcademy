using System;
using System.IO;

class PrintOddlines
{
    static void Main()
    {
        string filename = "lyrics.txt";
        StreamReader streamReader = new StreamReader(filename);
        int line = 0;
        while (!streamReader.EndOfStream)
        {
            if (line % 2 == 0)
            {
                Console.WriteLine(streamReader.ReadLine());
            } 
            else
            {
                streamReader.ReadLine();
            }
            line++;
        }
        streamReader.Dispose();
    }
}

