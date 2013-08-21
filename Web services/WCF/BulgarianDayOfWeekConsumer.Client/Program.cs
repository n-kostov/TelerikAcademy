using BulgarianDayOfWeekConsumer.Client.BulgarianDayOfWeekService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulgarianDayOfWeekConsumer.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            BulgarianDayOfWeekCalculatorClient calculatorClient = new BulgarianDayOfWeekCalculatorClient();
            string result = calculatorClient.GetDayOfWeek(new DateTime(2013,8,11));
            System.Console.WriteLine("The result returned by the WCF service is: " + result);
        }
    }
}
