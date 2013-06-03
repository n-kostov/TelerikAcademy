using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.School
{
    public class Student : Human, ICommentable
    {
        private int classNumber;

        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Class number cannot be less than or equal to 0");
                }
                this.classNumber = value;
            }
        }

        public Student(int classNumber, string name)
            : base(name)
        {
            this.classNumber = classNumber;
        }

        public string Comment { get; set; }

        public void AddComment(string comment)
        {
            Comment = comment;
        }
    }
}
