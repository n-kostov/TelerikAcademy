using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class RemoveAllWords
{

    static void RemoveGivenWordsFromFile(string fileName, string wordsFileName)
    {

        StreamReader streamReader2 = null;
        List<string> words = new List<string>();
        try
        {
            streamReader2 = new StreamReader(wordsFileName);
            while (!streamReader2.EndOfStream)
            {
                words.Add(streamReader2.ReadLine());
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file {0} cannot be found", wordsFileName);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The file {0} is not in this directory", wordsFileName);
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("You gave too long path");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Cannot use null arguments");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("You cannot use blank path or special characters for a path");
        }

        finally
        {
            if (streamReader2 != null)
            {
                streamReader2.Dispose();
            }
        }

        StreamReader streamReader = null;
        string text = "";
        try
        {
            streamReader = new StreamReader(fileName);
            text = streamReader.ReadToEnd();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The file {0} cannot be found", fileName);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The file {0} is not in this directory", fileName);
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("You gave too long path");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Cannot use null arguments");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("You cannot use blank path or special characters for a path");
        }
        finally
        {
            if (streamReader != null)
            {
                streamReader.Dispose();
            }
        }

        StreamWriter streamWriter = null;
        try
        {
            streamWriter = new StreamWriter("result.txt");
            foreach (var item in words)
            {
                string pattern = string.Format(@"\b{0}\b", item);
                Regex regex = new Regex(pattern);
                text = regex.Replace(text, "");
            }
            streamWriter.Write(text);
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("You gave too long path");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Cannot use null arguments");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("You cannot use blank path or special characters for a path");
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }


    }

    static void Main()
    {
        string fileName = "file.txt";
        string wordsFileName = "words.txt";
        RemoveGivenWordsFromFile(fileName, wordsFileName);
    }
}

