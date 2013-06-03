using System;

namespace _2.HumanLists_SortAndMerge
{
    public class Student : Human
    {
        private float grade;

        public float Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < 2 || value > 6)
                {
                    Console.WriteLine("The grade cannot be less than 2.00 or greater than 6.00");
                }
                else
                {
                    this.grade = value;
                }
            }
        }

        public Student(string firstName, string lastName, float grade)
            : base(firstName, lastName)
        {
            Grade = grade;
        }
    }
}
