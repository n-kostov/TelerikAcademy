using System;

public class Student
{
    private string name;

    private int id;

    public Student(string name, int id)
    {
        this.Name = name;
        this.Id = id;
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
                throw new ArgumentException("The student's name cannot be null or empty.", "value");
            }

            this.name = value;
        }
    }

    public int Id
    {
        get
        {
            return this.id;
        }

        set
        {
            if (value >= 10000 && value <= 99999)
            {
                this.id = value;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The id of the student" + this.Name +
                    "should be between 10000 and 99999!");
            }
        }
    }
}