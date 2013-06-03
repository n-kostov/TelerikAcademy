using System;

class Dictionary
{
    static void Main()
    {
        string dictionary = ".NET – platform for applications from Microsoft\nCLR – managed execution environment for .NET\nnamespace – hierarchical organization of classes";
        string[] definitions = dictionary.Split('\n');
        Console.Write("word = ");
        string word = Console.ReadLine();
        string translation = "";
        foreach (var item in definitions)
        {
            if (word == item.Substring(0, item.IndexOf(" ")))
            {
                translation = item;
                break;
            }
        }
        if (translation == "")
        {
            Console.WriteLine("We don't have this word in the dictionary");
        }
        else
        {
            Console.WriteLine("Translation:\n{0}", translation);
        }
    }
}

