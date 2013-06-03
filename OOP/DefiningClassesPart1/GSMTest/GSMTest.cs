using System;
using GSMUtils;

    class GSMTest
    {
        static void Main(string[] args)
        {
            GSM[] gsmArray = new GSM[3];

            Battery myBattery = new Battery("Nokia", 50,50, BatteryType.LiIon);
            Display myDisplay = new Display(10, 1000000);
            GSM firstGsm = new GSM("N8", "Nokia", 500, "Me", myBattery, myDisplay);
            gsmArray[0] = firstGsm;

            myBattery = new Battery("Samsung", 60, 60, BatteryType.NiCd);
            myDisplay = new Display(12, 1200000);
            GSM secondGsm = new GSM("Galaxy", "Samsung", 700, "Me", myBattery, myDisplay);
            gsmArray[1] = secondGsm;

            myBattery = new Battery("HTC", 40, 40, BatteryType.NiMH);
            myDisplay = new Display(8, 800000);
            GSM thirdGsm = new GSM("K8", "HTC", 450, "Me", myBattery, myDisplay);
            gsmArray[2] = thirdGsm;

            foreach (var item in gsmArray)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            Console.WriteLine(GSM.IPhone4S);

            GSMCallHistoryTest.Test();
        }
    }

