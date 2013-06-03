using System.IO;
using System;
using System.Text;
using System.Text.RegularExpressions;

class DeleteWordsWithPrefix
{
    static void Main()
    {
        
        string fileName = "file.txt";
        StreamReader streamReader = new StreamReader(fileName);
        string text = streamReader.ReadToEnd();
        streamReader.Dispose();
        string pattern = @"\btest\w*\b";
        Regex regex = new Regex(pattern);
        text = regex.Replace(text,"");
        StreamWriter streamWriter = new StreamWriter(fileName);
        streamWriter.Write(text);
        streamWriter.Dispose();
    }
}

