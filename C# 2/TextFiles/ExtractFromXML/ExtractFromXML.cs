using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class ExtractFromXML
{
    static void Main()
    {
        string fileName = "file.xml";
        StreamReader streamReader = new StreamReader(fileName,Encoding.GetEncoding("windows-1251"));
        string text = streamReader.ReadToEnd();
        streamReader.Dispose();
        int indexleft = text.IndexOf('>',0);
        int indexRight = text.IndexOf('<', indexleft);
        List<string> words = new List<string>();
        while (indexleft != -1 && indexRight != -1)
        {
            
            if (indexRight != -1 && indexRight != indexleft + 1)
            {
                words.Add(text.Substring(indexleft + 1, indexRight - indexleft - 1).Trim());
            }
            indexleft++;
            indexleft = text.IndexOf('>', indexleft);
            indexRight = text.IndexOf('<', indexleft);
        }
        for (int i = 0; i < words.Count; i++)
        {
            if (words[i] == "")
            {
                words.Remove(words[i]);
                i--;
            }
            else
            {
                Console.WriteLine(words[i]);
            }
        }
    }
}

