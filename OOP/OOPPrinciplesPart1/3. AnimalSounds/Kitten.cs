using System;

namespace _3.AnimalSounds
{
    public class Kitten : Cat
    {

        public Kitten(int age, string name)
            : base(age, name, Gender.Female)
        {

        }

        public override void PlaySound()
        {
            Console.WriteLine("Myau! I am a kitten.");
        }

    }
}
