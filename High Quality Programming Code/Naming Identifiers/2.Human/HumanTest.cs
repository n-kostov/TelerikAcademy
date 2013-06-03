using System;

internal class HumanTest
{
    public static void Main()
    {
        Human man = CreateHuman(16);
        Human woman = CreateHuman(17);

        Console.WriteLine(man.Name + " is " + man.Age + " years old " + man.Gender);
        Console.WriteLine(woman.Name + " is " + woman.Age + " years old " + woman.Gender);
    }

    public static Human CreateHuman(int age)
    {
        Human human = new Human();
        human.Age = age;

        if (age % 2 == 0)
        {
            human.Name = "Батката";
            human.Gender = Gender.Male;
        }
        else
        {
            human.Name = "Мацето";
            human.Gender = Gender.Female;
        }

        return human;
    }
}