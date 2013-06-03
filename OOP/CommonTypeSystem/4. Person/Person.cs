using System;

public class Person
{
    string name;
    int? age;

    string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
    }

    int? Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("The age of the person cannot be less than 0");
            }
            this.age = value;
        }
    }

    public Person(string name, int? age = null)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        if (this.age == null)
        {
            return string.Format("{0} has no age specified", this.name);
        }
        else
        {
            return string.Format("{0} is {1} years old", this.name, this.age);
        }
    }
}
