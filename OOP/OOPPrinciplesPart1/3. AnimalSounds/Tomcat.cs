using System;

namespace _3.AnimalSounds
{
    public class Tomcat : Cat
    {

        public Tomcat(int age, string name)
            : base(age, name, Gender.Male)
        {

        }

        public override void PlaySound()
        {
            Console.WriteLine("Myauuu! I am a tomcat.");
        }

    }
}
