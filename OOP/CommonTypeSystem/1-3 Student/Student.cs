using System;

public class Student : ICloneable, IComparable<Student>
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string SSN { get; set; }
    public string Address { get; set; }
    public string MobilePhone { get; set; }
    public string EMail { get; set; }
    public int Course { get; set; }
    public Specialty Specialty { get; set; }
    public University University { get; set; }
    public Faculty Faculty { get; set; }

    public Student(string firstName, string middleName, string lastName, string ssn, string address, string mobilePhone, string eMail, int course, Specialty specialty, University university, Faculty faculty)
    {
        this.FirstName = firstName;
        this.MiddleName = middleName;
        this.LastName = lastName;
        this.SSN = ssn;
        this.Address = address;
        this.MobilePhone = mobilePhone;
        this.EMail = eMail;
        this.Course = course;
        this.Specialty = specialty;
        this.University = university;
        this.Faculty = faculty;
    }

    public override bool Equals(object obj)
    {
        Student student = obj as Student;

        if (student == null)
        {
            return false;
        }

        // we know that SSN is unique for every student
        if (!Object.Equals(this.SSN, student.SSN))
        {
            return false;
        }

        return true;
    }

    public static bool operator ==(Student student, Student student2)
    {
        return Student.Equals(student, student2);
    }

    public static bool operator !=(Student student, Student student2)
    {
        return !Student.Equals(student, student2);
    }

    public override string ToString()
    {
        return String.Format("Student {0} {1} {2} has SSN: {3}", this.FirstName, this.MiddleName, this.LastName, this.SSN);
    }

    public override int GetHashCode()
    {
        // SSN is unique so the string GetHashCode will give unique hash code for every student
        return SSN.GetHashCode();
    }

    public object Clone()
    {
        Student student = (Student)this.MemberwiseClone();
        //  student.Test = new TestField();  if there was a referent field in the Student class we need to make new instances for them
        return student;
    }

    public int CompareTo(Student other)
    {
        if (this.FirstName != other.FirstName)
        {
            return this.FirstName.CompareTo(other.FirstName);
        }
        else if (this.MiddleName != other.MiddleName)
        {
            return this.MiddleName.CompareTo(other.MiddleName);
        }
        else if (this.LastName != other.LastName)
        {
            return this.LastName.CompareTo(other.LastName);
        }
        else
        {
            return this.SSN.CompareTo(other.SSN);
        }
    }
}

