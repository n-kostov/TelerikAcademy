using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Globalization;

namespace BulgarianDayOfWeekService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BulgarianDayOfWeekCalculator" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BulgarianDayOfWeekCalculator.svc or BulgarianDayOfWeekCalculator.svc.cs at the Solution Explorer and start debugging.
    public class BulgarianDayOfWeekCalculator : IBulgarianDayOfWeekCalculator
    {
        public string GetDayOfWeek(DateTime date)
        {
            string dayOfWeek = date.ToString("dddd", new CultureInfo("bg-BG"));
            return dayOfWeek;
        }
    }
}
