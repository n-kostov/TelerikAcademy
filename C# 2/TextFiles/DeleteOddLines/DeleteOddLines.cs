using System;
using System.IO;

class DeleteOddLines
{
    static void Main()
    {
        string fileName = "lyrics.txt";
        StreamReader streamReader = new StreamReader(fileName);
        string[] lines = streamReader.ReadToEnd().Split('\n');
        streamReader.Dispose();
        StreamWriter streamWriter = new StreamWriter(fileName);
        for (int i = 0; i < lines.Length; i++)
        {
            if (i % 2 == 0)
            {
                streamWriter.WriteLine(lines[i]);
            }
        }
        streamWriter.Dispose();
    }
}

