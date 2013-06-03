using System.Collections.Generic;
using System;
using System.IO;

class SotTextFile
{
    static void Main()
    {
        List<string> list = new List<string>();
        string fileName = "names.txt";
        StreamReader streamReader = new StreamReader(fileName);
        while (!streamReader.EndOfStream)
        {
            list.Add(streamReader.ReadLine());
        }
        streamReader.Dispose();
        list.Sort();
        string resultFileName = "result.txt";
        StreamWriter streamWriter = new StreamWriter(resultFileName);
        foreach (var item in list)
        {
            streamWriter.WriteLine(item);
        }
        streamWriter.Dispose();
    }
}

