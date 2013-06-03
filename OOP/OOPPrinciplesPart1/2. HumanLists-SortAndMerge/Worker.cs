using System;

namespace _2.HumanLists_SortAndMerge
{
    public class Worker : Human
    {
        private int weekSalary;
        private int workHoursPerDay;

        public int WeekSalary
        {
            get
            {
                return this.weekSalary;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("The week salary cannot be less than 0");
                }
                else
                {
                    this.weekSalary = value;
                }
            }
        }

        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("The work hours cannot be less than 0");
                }
                else
                {
                    this.workHoursPerDay = value;
                }
            }
        }

        public double MoneyPerHour()
        {
            return (double)WeekSalary / 5 / WorkHoursPerDay;
        }

        public Worker(string firstName, string lastName, int salary, int workHours)
            : base(firstName, lastName)
        {
            WeekSalary = salary;
            WorkHoursPerDay = workHours;
        }
    }
}
