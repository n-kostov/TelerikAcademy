using System;
using System.IO;

class InsertLineNumbers
{
    static void Main()
    {
        string fileName = "lyrics.txt";
        string resultFileName = "result.txt";
        StreamReader streamReader = new StreamReader(fileName);
        StreamWriter streamWriter = new StreamWriter(resultFileName);
        int lineNumber = 1;
        while (!streamReader.EndOfStream)
        {
            streamWriter.Write(lineNumber + ". ");
            streamWriter.WriteLine(streamReader.ReadLine());
            lineNumber++;
        }
        streamReader.Dispose();
        streamWriter.Dispose();
    }
}

