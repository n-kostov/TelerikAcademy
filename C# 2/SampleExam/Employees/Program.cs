using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees
{
    class Program
    {

        static int GetPriority(string[] positions, int[] priorities, string title)
        {
            int index = Array.BinarySearch(positions, title);
            return priorities[index];
        }
        
        static void Main(string[] args)
        {
            string[] positions =
            {
                "Trainee - 0",
                "Owner - 100",
                "CEO - 98",
                "Junior Developer - 30",
                "Unit Manager - 95",
                "Project Manager - 95",
                "Team Leader - 94",
                "Senior Developer - 50",
                "Developer - 40"
            };

            string[] employees = 
            {
                "Georgi Georgiev – Trainee",
                "Ademar Júnior – Unit Manager",
                "Dimitar Dimitrov – Owner",
                "Petar Atanasov – Project Manager",
                "Atanas Georgiev – Trainee",
                "Júnior Moraes – Trainee",
                "Ivan Bandalovski – Developer",
                "Apostol Popov – Developer",
                "Michel Platini – CEO",
                "Blagoy Makendzhiev - CEO"
            };

            

        }
    }
}
