using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.School
{
    public class Class : ICommentable
    {
        private List<Teacher> teachers = new List<Teacher>();
        private List<Student> students = new List<Student>();

        public Class(string id)
        {
            ClassID = id;
        }

        public List<Student> Students
        {
            get
            {
                return this.students.AsReadOnly().ToList();
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers.AsReadOnly().ToList();
            }
        }

        public void AddTeacher(Teacher teacherToAdd)
        {
            teachers.Add(teacherToAdd);
        }

        public void RemoveTeacher(Teacher teacherToDelete)
        {
            teachers.Add(teacherToDelete);
        }

        public void AddStudent(Student studentToAdd)
        {
            students.Add(studentToAdd);
        }

        public void RemoveStudent(Student studentToDelete)
        {
            students.Remove(studentToDelete);
        }

        public string ClassID { get; private set; }

        public string Comment { get; set; }

        public void AddComment(string comment)
        {
            Comment = comment;
        }
    }
}
