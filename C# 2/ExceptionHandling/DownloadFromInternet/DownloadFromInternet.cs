using System;
using System.Net;

class DownloadFromInternet
{
    static void Main()
    {
        WebClient webClient = new WebClient();
        string linkToFile = @"http://www.devbg.org/img/Logo-BASD.jpg";
        try
        {
            webClient.DownloadFile( linkToFile,"logo.jpg");
        }

        catch (ArgumentNullException)
        {
            Console.WriteLine("You can't use null arguments");
        }
        catch (ArgumentException)
        {
            Console.WriteLine("'{0}' is a wrong path", linkToFile);
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Use different slashes for this operating system");
        }
        catch (WebException)
        {
            Console.WriteLine("Not file specified to save to");
        }
        finally
        {
            webClient.Dispose();
        }

    }
}

