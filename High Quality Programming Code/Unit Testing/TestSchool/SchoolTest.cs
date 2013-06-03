namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTest
    {
        [TestMethod]
        public void TestAddCourse1()
        {
            School school = new School();
            Course course = new Course("C#");

            school.AddCourse(course);
            Assert.AreEqual(1, school.Courses.Count, "Couldn't add the course.");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestAddCourse2_ThrowsException()
        {
            School school = new School();
            school.AddCourse(null);
        }

        [TestMethod]
        public void TestRemoveCourse1()
        {
            School school = new School();
            Course course = new Course("C#");

            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(0, school.Courses.Count, "Couldn't remove the course.");
        }
    }
}
