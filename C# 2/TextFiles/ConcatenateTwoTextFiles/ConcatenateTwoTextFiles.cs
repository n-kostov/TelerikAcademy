using System;
using System.IO;

class ConcatenateTwoTextFiles
{
    static void Main()
    {
        string fileName1 = "file1.txt";
        string fileName2 = "file2.txt";
        string fileNameResult = "result.txt";
        StreamReader streamReader = new StreamReader(fileName1);
        StreamWriter streamWriter = new StreamWriter(fileNameResult);
        streamWriter.WriteLine(streamReader.ReadToEnd());
        streamReader.Dispose();
        streamReader = new StreamReader(fileName2);
        streamWriter.Write(streamReader.ReadToEnd());
        streamReader.Dispose();
        streamWriter.Dispose();
    }
}

