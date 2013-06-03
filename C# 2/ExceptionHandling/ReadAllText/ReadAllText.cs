using System;
using System.IO;
using System.Text;


class ReadAllText
{
    static void Main()
    {
        Console.Write("Enter the path to the file:");
        string path = Console.ReadLine();
        try
        {
            string content = File.ReadAllText(path,Encoding.GetEncoding("windows-1251"));
            Console.WriteLine(content);
             
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File '{0}' cannot be found", path);
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Incorrect path or directory in '{0}'", path);
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The path you entered is too long");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Argument cannot be null");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("Your cant use blank path or special symbols in file path");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("You don't have access to this file '{0}'",path);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Use different slashes for this operating system");
        }
        finally
        {
            // the file is already closed - ReadAllText always closes the file
        }
    }
}

