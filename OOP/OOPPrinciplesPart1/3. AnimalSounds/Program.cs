using System;
using System.Linq;

//  3.Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors and methods.
//  Dogs, frogs and cats are Animals. All animals can produce sound (specified by the ISound interface).
//  Kittens and tomcats are cats. All animals are described by age, name and sex.
//  Kittens can be only female and tomcats can be only male. Each animal produces a specific sound.
//  Create arrays of different kinds of animals and calculate the average age of each kind of animal using a static method 
//  (you may use LINQ).

namespace _3.AnimalSounds
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal[] animals = { new Kitten(1, "Kitty"), new Tomcat(4, "Tom"), new Dog(8, "Sparky", Gender.Male), new Frog(3, "Froggy", Gender.Female) };

            foreach (var animal in animals)
            {
                animal.PlaySound();
            }

            Console.WriteLine();

            Frog[] frogs =
            {
                new Frog( 2, "Frog1", Gender.Female),
                new Frog( 8, "Frog2", Gender.Male),
                new Frog( 6, "Frog3", Gender.Male),
                new Frog( 7, "Frog4", Gender.Female)
            };
            Dog[] dogs =
            {
                new Dog( 4, "Dog1", Gender.Female),
                new Dog( 7, "Dog2", Gender.Male),
                new Dog( 8, "Dog3", Gender.Male),
                new Dog( 10, "Dog4", Gender.Male)
            };
            Cat[] cats =
            {
                new Kitten( 3, "Cat1"),
                new Tomcat( 5, "Cat2"),
                new Kitten( 2, "Cat3"),
                new Tomcat( 1, "Cat4")
            };

            Console.WriteLine("Average age of frogs " + frogs.Average(x => x.Age));
            Console.WriteLine("Average age of dogs " + dogs.Average(x => x.Age));
            Console.WriteLine("Average age of cats " + cats.Average(x => x.Age));


        }
    }
}
