using System;
using System.Collections.Generic;

namespace GSMUtils
{
    public class GSM
    {
        private string model;
        private string manufacturer;
        private double? price;
        private string owner;
        private readonly Battery gsmBattery = new Battery(null);
        private readonly Display gsmDisplay = new Display();
        private static GSM iPhone = new GSM("4S", "Apple", 1000, "Me", new Battery("Apple", 100, 20,BatteryType.LiIon), new Display(15, 1200));
        private List<Call> callHistory = new List<Call>();

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                this.callHistory = value;
            }
        }

        public static GSM IPhone4S
        {
            get
            {
                return iPhone;
            }
            set
            {
                iPhone = value;
            }
        }

        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public double? Price
        {
            get
            {
                return this.price;
            }
            set
            {
                this.price = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
            }
        }

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null)
        {
        }

        public GSM(string model, string manufacturer, double? price)
            : this(model, manufacturer, price, null)
        {
        }

        public GSM(string model, string manufacturer, double? price, string owner)
            : this(model, manufacturer, price, owner, null, null)
        {
        }

        public GSM(string model, string manufacturer, double? price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.owner = owner;
            gsmBattery = battery;
            gsmDisplay = display;
        }

        public string Print()
        {
            return ToString();
        }

        public override string ToString()
        {
            string result = string.Format("This is {0} {1}. {2} bought it for {3} $. It comes with \nBattery: {4} - {5}, {6} hoursIdle, {7} hoursTalk \nDisplay: {8} inches and {9} colors", manufacturer, model, owner, price, gsmBattery.Model, gsmBattery.Type, gsmBattery.HoursIdle, gsmBattery.HoursTalk, gsmDisplay.Size, gsmDisplay.NumberOfColors);    
            return result;
        }

        public void AddCall(Call newCall)
        {
            callHistory.Add(newCall);
        }

        public void DeleteCall(Call callToDelete)
        {
            callHistory.Remove(callToDelete);
        }

        public void ClearCallHistory()
        {
            callHistory.Clear();
        }

        public double CalculatePriceOfCalls(double pricePerMinute)
        {
            double result = 0;
            foreach (var item in callHistory)
            {
                result += item.Duration / 60 * pricePerMinute;
            }
            return result;
        }

        public void RemoveLongestCall()
        {
            int max = 0;
            Call longestCall = null;
            foreach (var item in callHistory)
            {
                if (item.Duration > max)
                {
                    max = item.Duration;
                    longestCall = item;
                }
            }
            if (longestCall != null)
            {
                DeleteCall(longestCall);
            }
        }

    }
}
