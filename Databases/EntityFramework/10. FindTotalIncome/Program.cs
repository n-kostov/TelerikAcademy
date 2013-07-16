using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.FindTotalIncome
{
    class Program
    {
        static void Main(string[] args)
        {
            NorthwindEntities context = new NorthwindEntities();
            double income = context.FindTotalIncomeBySupplier("Leka Trading").First().Value;
            Console.WriteLine(income);

            income = context.FindTotalIncomeByPeriod(new DateTime(1997, 1, 1), new DateTime(1997, 6, 6)).First().Value;
            Console.WriteLine(income);

            income = context.FindTotalIncomeBySupplierAndPeriod("Leka Trading", 
                new DateTime(1997, 1, 1), new DateTime(1997, 6, 6)).First().Value;
            Console.WriteLine(income);
        }
    }
}
