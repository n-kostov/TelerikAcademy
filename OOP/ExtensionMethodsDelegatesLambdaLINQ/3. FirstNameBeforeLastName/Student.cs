using System;

namespace _3.FirstNameBeforeLastName
{
    public class Student
    {
        private string firstName;
        private string lastName;

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
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
    }
}
