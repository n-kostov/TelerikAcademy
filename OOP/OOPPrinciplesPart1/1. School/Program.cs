using System;
using System.Collections.Generic;

//  1.We are given a school. In the school there are classes of students. Each class has a set of teachers. 
//  Each teacher teaches a set of disciplines. Students have name and unique class number. Classes have unique text identifier.
//  Teachers have name. Disciplines have name, number of lectures and number of exercises.
//  Both teachers and students are people. Students, classes, teachers and disciplines could have optional comments (free text block).
//	Your task is to identify the classes (in terms of  OOP) and their attributes and operations, encapsulate their fields,
//  define the class hierarchy and create a class diagram with Visual Studio.
    

namespace _1.School
{
    class Program
    {
        static void Main(string[] args)
        {
            Teacher classTeacher = new Teacher("Pesho");
            Discipline discipline = new Discipline();
            discipline.Name = "English";
            discipline.NumberOfExercises = 15;
            discipline.NumberOfLectures = 30;
            classTeacher.AddDiscipline(discipline);

            List<Discipline> list = classTeacher.Disciplines;
            // add to this list does not change the internal list of disciplines
            list.Add(new Discipline { Name = "Biology", NumberOfLectures = 60, NumberOfExercises = 30 });

            Student student1 = new Student(1,"Ani");
            Student student2 = new Student(2, "Gosho");

            Class mySchoolClass = new Class("a");
            mySchoolClass.AddStudent(student1);
            mySchoolClass.AddStudent(student2);
            mySchoolClass.AddTeacher(classTeacher);

            School mySchool = new School();
            mySchool.AddClass(mySchoolClass);

            mySchool.AddComment("My school");
            Console.WriteLine(mySchool.Comment);
        }
    }
}
