using System;

class URLAddressParser
{
    static void Main()
    {
        string url = @"http://www.devbg.org/forum/index.php";
        int index = url.IndexOf(':');
        string protocol = url.Substring(0, index);
        Console.WriteLine(protocol);
        index = url.IndexOf(@"//", index + 1);
        string server = url.Substring(index + 2, url.IndexOf(@"/", index + 2) - index -2);
        Console.WriteLine(server);
        string resource = url.Substring(url.IndexOf(@"/", index + 2));
        Console.WriteLine(resource);
    }
}

