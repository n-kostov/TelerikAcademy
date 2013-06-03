using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public bool IsOlderThan(Student other)
        {
            return this.Birthdate.CompareTo(other.Birthdate) < 0;
        }
    }
}
