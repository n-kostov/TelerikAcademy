namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourseConstructor1()
        {
            Course course = new Course("C#");

            Assert.AreEqual("C#", course.Name, "Course name not set correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor3_ThrowsException()
        {
            Course course = new Course(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor4_ThrowsException()
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructor5_ThrowsException()
        {
            Course course = new Course(" ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddStudent1_ThrowsException()
        {
            Course course = new Course("C#");
            course.AddStudent(null);
        }

        [TestMethod]
        public void TestAddStudent2()
        {
            Course course = new Course("C#");
            Student student = new Student("pesho", 23134);
            course.AddStudent(student);

            Assert.AreEqual(1, course.Students.Count, "Couldn't add the student to the course.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddStudent3_ThrowsException()
        {
            Course course = new Course("C#");
            for (int i = 0; i < Course.MaxStudentsCount + 1; i++)
            {
                course.AddStudent(new Student("pesho", 34245 + i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestAddStudent4_ThrowsException()
        {
            Course course = new Course("C#");

            Student pesho = new Student("pesho", 34254);
            course.AddStudent(pesho);

            Student maria = new Student("maria", 34254);
            course.AddStudent(maria);

        }

        [TestMethod]
        public void TestRemoveStudent1()
        {
            Course course = new Course("C#");
            Student student = new Student("pesho", 32533);
            course.AddStudent(student);
            bool studentRemoved = course.RemoveStudent(student);

            Assert.AreEqual(true, studentRemoved, "Couldn't remove student.");
            Assert.AreEqual(0, course.Students.Count, "Couldn't remove student.");
        }

        [TestMethod]
        public void TestRemoveStudent2()
        {
            Course course = new Course("C#");
            Student student = new Student("pesho", 35253);
            course.AddStudent(student);
            bool studentRemoved = course.RemoveStudent(new Student("gosho", 56532));

            Assert.AreEqual(false, studentRemoved, "Non-existent student removed.");
            Assert.AreEqual(1, course.Students.Count, "Non-existent student removed.");
        }

        [TestMethod]
        public void TestRemoveStudent3()
        {
            Course course = new Course("C#");
            Student student = new Student("pesho", 67432);
            course.AddStudent(student);
            bool studentRemoved = course.RemoveStudent(null);

            Assert.AreEqual(false, studentRemoved, "Non-existent student removed.");
            Assert.AreEqual(1, course.Students.Count, "Non-existent student removed.");
        }
    }
}
