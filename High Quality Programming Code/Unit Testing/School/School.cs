using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

public class School
{
    private IList<Course> courses;

    public School()
    {
        this.courses = new List<Course>();
    }

    public IList<Course> Courses
    {
        get
        {
            return new ReadOnlyCollection<Course>(this.courses);
        }
    }

    public void AddCourse(Course course)
    {
        if (course == null)
        {
            throw new ArgumentNullException("course", "The course cannot be null.");
        }

        this.courses.Add(course);
    }

    public bool RemoveCourse(Course course)
    {
        return this.courses.Remove(course);
    }
}