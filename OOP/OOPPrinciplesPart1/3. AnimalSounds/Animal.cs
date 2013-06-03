using System;

namespace _3.AnimalSounds
{
    public abstract class Animal : ISound
    {
        private int age;
        private string name;
        private Gender sex;

        public Animal(int age, string name, Gender sex)
        {
            Age = age;
            Name = name;
            Sex = sex;
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("The animal must be already born!");
                }
                this.age = value;
            }
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
                    throw new ArgumentNullException("The animal's name cannot be null");
                }
                this.name = value;
            }
        }

        public Gender Sex
        {
            get
            {
                return this.sex;
            }
            set
            {
                this.sex = value;
            }
        }

        public abstract void PlaySound();

    }
}
