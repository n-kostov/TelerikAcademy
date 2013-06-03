namespace TestSchool
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor1_ThrowsException()
        {
            Student student = new Student(null, 43534);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor2_ThrowsException()
        {
            Student student = new Student(string.Empty, 43346);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestStudentConstructor3_ThrowsException()
        {
            Student student = new Student(" ", 34534);
        }

        [TestMethod]
        public void TestStudentConstructor4()
        {
            Student student = new Student("pesho", 43564);

            Assert.AreEqual("pesho", student.Name, "Student's name is not set correctly.");
        }

        [TestMethod]
        public void TestStudentConstructor5()
        {
            Student student = new Student("pesho", 10001);

            string format = string.Format(
                "Student's Id does not fall within the expected range from {0} to {1}.",
                10000,
                99999);

            Assert.IsTrue(10000 <= student.Id || student.Id >= 99999, format);
        }

        [TestMethod]
        public void TestStudentConstructor6()
        {
            Student student = new Student("pesho", 10000);

            string format = string.Format(
                "Student's Id does not fall within the expected range from {0} to {1}.",
                10000,
                99999);

            Assert.IsTrue(10000 <= student.Id || student.Id >= 99999, format);
        }

        [TestMethod]
        public void TestStudentConstructor7()
        {
            Student student = new Student("pesho", 99999);

            string format = string.Format(
                "Student's Id does not fall within the expected range from {0} to {1}.",
                10000,
                99999);

            Assert.IsTrue(10000 <= student.Id || student.Id >= 99999, format);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestStudentConstructor8()
        {
            Student student = new Student("pesho", 100000);

        }
    }
}
