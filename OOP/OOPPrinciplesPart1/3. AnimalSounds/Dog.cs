using System;

namespace _3.AnimalSounds
{
    public class Dog : Animal
    {
        public Dog(int age, string name, Gender sex)
            : base(age, name, sex)
        {

        }

        public override void PlaySound()
        {
            Console.WriteLine("Bau! I am a dog.");
        }
    }
}
