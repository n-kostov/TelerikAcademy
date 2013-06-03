using System;

namespace _4.AllStudentsBetween18And24
{
    public class Student
    {
        private string firstName;
        private string lastName;
        private int age;


        public Student(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }


        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("First name cannot be null");
                }
                firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Last name cannot be null");
                }
                lastName = value;
            }
        }

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The age of the student cannot be less than 0!");
                }
                age = value;
            }
        }
    }
}
