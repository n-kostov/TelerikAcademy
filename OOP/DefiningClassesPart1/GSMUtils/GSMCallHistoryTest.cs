using System;

namespace GSMUtils
{
    public class GSMCallHistoryTest
    {
        public static void Test()
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("TEST BEGIN!!!");
            Console.WriteLine();

            GSM testPhone = GSM.IPhone4S;

            DateTime firstDate = new DateTime(2013, 1, 1, 12, 0, 0);
            DateTime secondDate = new DateTime(2013, 2, 28, 13, 0, 0);
            DateTime thirdDate = new DateTime(2013, 3, 3, 14, 3, 3);
            DateTime lastDate = DateTime.Now;

            Call firstCall = new Call(firstDate, "1234", 300);
            Call secondCall = new Call(secondDate, "5678", 600);
            Call thirdCall = new Call(thirdDate, "9012", 120);
            Call lastCall = new Call(lastDate, "3456", 80);

            testPhone.AddCall(firstCall);
            testPhone.AddCall(secondCall);
            testPhone.AddCall(thirdCall);
            testPhone.AddCall(lastCall);

            Console.WriteLine("Call History Information:");
            foreach (var item in testPhone.CallHistory)
            {
                item.Print();
            }
            Console.WriteLine();
            Console.WriteLine("Total price of the calls is: {0}$", testPhone.CalculatePriceOfCalls(0.37));

            testPhone.RemoveLongestCall();

            Console.WriteLine("Total price of the calls after removing the longest call is: {0}$", testPhone.CalculatePriceOfCalls(0.37));
            Console.WriteLine();

            Console.WriteLine("Call History Information:");
            foreach (var item in testPhone.CallHistory)
            {
                item.Print();
            }
            testPhone.ClearCallHistory();

        }
    }
}
