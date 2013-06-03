using System;

namespace _3.AnimalSounds
{
    public class Frog : Animal
    {
        public Frog(int age, string name, Gender sex)
            : base(age, name, sex)
        {

        }

        public override void PlaySound()
        {
            Console.WriteLine("Kwaak! I am a frog.");
        }
    }
}
