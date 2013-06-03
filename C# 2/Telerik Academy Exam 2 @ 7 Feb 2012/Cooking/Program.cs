using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> receipt = new List<string>(n);
            for (int i = 0; i < n; i++)
            {
                receipt.Add(Console.ReadLine());
            }
            //int m = int.Parse(Console.ReadLine());
            //List<string> productUsed = new List<string>();
            //for (int i = 0; i < m; i++)
            //{
            //    productUsed.Add(Console.ReadLine());
            //}
            Dictionary<string, double> measureUnits = new Dictionary<string, double>();
            measureUnits.Add("mls", 1);
            measureUnits.Add("milliliters", 1);
            measureUnits.Add("tsps", 5);
            measureUnits.Add("teaspoons", 5);
            measureUnits.Add("tbsps", 15);
            measureUnits.Add("tablespoons", 15);
            measureUnits.Add("fl ozs", 30);
            measureUnits.Add("fluid ounces", 30);
            measureUnits.Add("cups", 240);
            measureUnits.Add("pts", 480);
            measureUnits.Add("pints", 480);
            measureUnits.Add("qts", 960);
            measureUnits.Add("quarts", 960);
            measureUnits.Add("ls", 1000);
            measureUnits.Add("liters", 1000);
            measureUnits.Add("gals", 3840);
            measureUnits.Add("gallons", 3840);

            // remove multiple entries from receipt 
            for (int i = 0; i < receipt.Count - 1; i++)
            {
                double sum = 0;
                int rightIndex = receipt[i].LastIndexOf(':');
                string first = receipt[i].Substring(rightIndex + 1).ToLower();
                bool found = false;
                for (int j = i + 1; j < receipt.Count; j++)
                {
                    int rIndex = receipt[j].LastIndexOf(':');
                    if (first == receipt[j].Substring(rIndex + 1).ToLower())
                    {
                        int leftIndex = receipt[i].IndexOf(':');
                        int lIndex = receipt[j].IndexOf(':');
                        double secUnits = double.Parse(receipt[j].Substring(0, lIndex));
                        secUnits *= measureUnits[receipt[j].Substring(lIndex + 1, rIndex - lIndex - 1).ToLower()];
                        secUnits /= measureUnits[receipt[i].Substring(leftIndex + 1, rightIndex - leftIndex - 1).ToLower()];
                        double units = double.Parse(receipt[i].Substring(0, leftIndex));
                        sum += units + secUnits;
                        receipt.RemoveAt(j);
                        found = true;
                    }
                }
                if (found)
                {
                    receipt[i] = receipt[i].Replace(receipt[i].Substring(0, receipt[i].IndexOf(':')), sum.ToString());
                }
            }


            int m = int.Parse(Console.ReadLine());
            //List<string> productUsed = new List<string>();
            for (int i = 0; i < m; i++)
            {
                string product = Console.ReadLine();
                int rIndex = product.LastIndexOf(':');

                for (int j = 0; j < receipt.Count; j++)
                {
                    int rightIndex = receipt[j].LastIndexOf(':');
                    string first = receipt[j].Substring(rightIndex + 1).ToLower();

                    if (first == product.Substring(rIndex + 1).ToLower())
                    {
                        int leftIndex = receipt[j].IndexOf(':');
                        int lIndex = product.IndexOf(':');
                        double secUnits = double.Parse(product.Substring(0, lIndex));
                        secUnits *= measureUnits[product.Substring(lIndex + 1, rIndex - lIndex - 1).ToLower()];
                        secUnits /= measureUnits[receipt[j].Substring(leftIndex + 1, rightIndex - leftIndex - 1).ToLower()];
                        double units = double.Parse(receipt[j].Substring(0, leftIndex));

                        receipt[j] = receipt[j].Replace(units.ToString(), (units - secUnits).ToString());
                    }
                }
            }


            foreach (var item in receipt)
            {
                int index = item.IndexOf(':');
                if (double.Parse(item.Substring(0, index)) > 0)
                {
                    Console.WriteLine("{0:F2}{1}", double.Parse(item.Substring(0, index)), item.Substring(index));
                }
            }



            //for (int i = 0; i < productUsed.Count - 1; i++)
            //{
            //    double sum = 0;
            //    int rightIndex = productUsed[i].LastIndexOf(':');
            //    string first = productUsed[i].Substring(rightIndex + 1).ToLower();
            //    bool found = false;
            //    for (int j = i + 1; j < productUsed.Count; j++)
            //    {
            //        int rIndex = productUsed[j].LastIndexOf(':');
            //        if (first == productUsed[j].Substring(rIndex + 1).ToLower())
            //        {
            //            int leftIndex = productUsed[i].IndexOf(':');
            //            int lIndex = productUsed[j].IndexOf(':');
            //            double secUnits = double.Parse(productUsed[j].Substring(0, lIndex));
            //            secUnits *= measureUnits[productUsed[j].Substring(lIndex + 1, rIndex - lIndex - 1).ToLower()];
            //            secUnits /= measureUnits[productUsed[i].Substring(leftIndex + 1, rightIndex - leftIndex - 1).ToLower()];
            //            double units = double.Parse(productUsed[i].Substring(0, leftIndex));
            //            sum += units + secUnits;
            //            productUsed.RemoveAt(j);
            //            found = true;
            //        }
            //    }
            //    if (found)
            //    {
            //        productUsed[i] = productUsed[i].Replace(productUsed[i].Substring(0, productUsed[i].IndexOf(':')), sum.ToString());
            //    }
            //}

            // search for the product used

            //for (int i = 0; i < receipt.Count; i++)
            //{
            //    int rightIndex = receipt[i].LastIndexOf(':');
            //    string first = receipt[i].Substring(rightIndex + 1).ToLower();
            //    bool found = true;
            //    for (int j = 0; j < productUsed.Count; j++)
            //    {
            //        int rIndex = productUsed[j].LastIndexOf(':');
            //        if (first == productUsed[j].Substring(rIndex + 1).ToLower())
            //        {
            //            int leftIndex = receipt[i].IndexOf(':');
            //            int lIndex = productUsed[j].IndexOf(':');
            //            double secUnits = double.Parse(productUsed[j].Substring(0, lIndex));
            //            secUnits *= measureUnits[productUsed[j].Substring(lIndex + 1, rIndex - lIndex - 1).ToLower()];
            //            secUnits /= measureUnits[receipt[i].Substring(leftIndex + 1, rightIndex - leftIndex - 1).ToLower()];
            //            double units = double.Parse(receipt[i].Substring(0, leftIndex));

            //            //receipt[i] = receipt[i].Replace(units.ToString(), (units + secUnits).ToString());
            //            if (secUnits - units < 0)
            //            {
            //                Console.WriteLine("{0:f2}{1}", units - secUnits, receipt[i].Substring(leftIndex));
            //            }

            //            productUsed.RemoveAt(j);
            //            found = false;
            //        }
            //    }
            //    if (found)
            //    {
            //        int leftIndex = receipt[i].IndexOf(':');
            //        double units = double.Parse(receipt[i].Substring(0, leftIndex));
            //        Console.WriteLine("{0:f2}{1}", units, receipt[i].Substring(leftIndex));
            //    }
            //}

        }
    }
}
