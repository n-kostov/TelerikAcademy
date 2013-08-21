using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCount.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            StringCounterInTextClient calculatorClient = new StringCounterInTextClient();
            int result = calculatorClient.CountOccurrance("I am in a narrow city in Bulgaria as sideline", "in");
            Console.WriteLine("The result returned by the WCF service is: " + result);
        }
    }
}