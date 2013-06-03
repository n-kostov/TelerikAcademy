using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class Course
{
    public const int MaxStudentsCount = 30;

    private string name;

    private IList<Student> students;

    public Course(string name)
    {
        this.Name = name;
        this.students = new List<Student>();
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
                throw new ArgumentException("The course name cannot be null or empty.", "value");
            }

            this.name = value;
        }
    }

    public IList<Student> Students
    {
        get
        {
            return new ReadOnlyCollection<Student>(this.students);
        }
    }

    public void AddStudent(Student student)
    {
        if (student == null)
        {
            throw new ArgumentNullException("student", "The student cannot be null.");
        }

        if (this.students.Count == MaxStudentsCount)
        {
            throw new InvalidOperationException(
                string.Format(
                "Student cannot be added. Course attendants have reached the maximum number ({0}).",
                MaxStudentsCount));
        }

        for (int i = 0; i < students.Count; i++)
        {
            if (students[i].Id == student.Id)
            {
                throw new InvalidOperationException(
                string.Format(
                "Student cannot be added. There is already student with this id"));
            }
        }

        this.students.Add(student);
    }

    public bool RemoveStudent(Student student)
    {
        return this.students.Remove(student);
    }
}