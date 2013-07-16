using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01.UsingEntityFrameworkModel;

namespace _07.ConcurrentChanges
{
    class Program
    {
        static void Main(string[] args)
        {
            UpdateRegion();
        }

        public static void UpdateRegion()
        {
            NorthwindEntities context1 = new NorthwindEntities();
            Region region1 = context1.Regions.First();

            region1.RegionDescription = "Africa";

            NorthwindEntities context2 = new NorthwindEntities();
            Region region2 = context2.Regions.First();

            region2.RegionDescription = "Europe";

            context2.SaveChanges();
            context1.SaveChanges();

            // use transactions
        }
    }
}
