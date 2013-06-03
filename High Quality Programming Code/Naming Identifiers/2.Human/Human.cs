using System;

internal class Human
{
    private Gender gender;
    private string name;
    private int age;

    public Gender Gender
    {
        get
        {
            return this.gender;
        }
        set
        {
            this.gender = value;
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
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("The name cannot be null or empty.");
            }
            this.name = value;
        }
    }

    public int Age
    {
        get
        {
            return this.age;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("The age must be positive.");
            }
            this.age = value;
        }
    }

}
