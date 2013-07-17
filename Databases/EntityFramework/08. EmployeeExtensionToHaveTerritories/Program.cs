using _01.UsingEntityFrameworkModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.EmployeeExtensionToHaveTerritories
{
    class Program
    {
        public static void Main()
        {
            NorthwindEntities context = new NorthwindEntities();
            Employee employee = context.Employees.First();
            foreach (var territory in employee.EntityTerritories)
            {
                Console.WriteLine(territory.TerritoryDescription);
            }
            
        }
    }
}
