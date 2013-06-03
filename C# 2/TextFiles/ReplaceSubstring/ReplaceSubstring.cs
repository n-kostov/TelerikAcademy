using System;
using System.IO;

class ReplaceSubstring
{
    static void Main()
    {
        string fileName = "file.txt";
        StreamReader streamReader = new StreamReader(fileName);
        string str = streamReader.ReadToEnd().Replace(" start ", " finish ");
        streamReader.Dispose();
        StreamWriter streamWriter = new StreamWriter(fileName);
        streamWriter.Write(str);
        streamWriter.Dispose();
    }
}

