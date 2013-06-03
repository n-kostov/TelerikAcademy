using System;

namespace _1.School
{
    public abstract class Human
    {
        private string name;

        public Human(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The name cannot be null");
                }
                this.name = value;
            }
        }
    }
}
