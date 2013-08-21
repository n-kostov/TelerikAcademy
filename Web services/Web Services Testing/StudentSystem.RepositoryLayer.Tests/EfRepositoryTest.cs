using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;
using StudentSystem.Model;
using StudentSystem.DataLayer;
using System.Data.Entity.Validation;

namespace StudentSystem.RepositoryLayer.Tests
{
    [TestClass]
    public class EfRepositoryTest
    {
        private TransactionScope tran;
        private EfRepository<Student> studentsRepository;
        private StudentSystemContext context;

        public EfRepositoryTest()
        {
            this.context = new StudentSystemContext();
            this.studentsRepository = new EfRepository<Student>(this.context);
        }

        [TestInitialize]
        public void TestInit()
        {
            tran = new TransactionScope();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Add_WhenNameIsValid_ShouldAddToDatabase()
        {
            string studentName = "PEsho";
            Student student = new Student
            {
                FirstName = studentName,
                LastName = studentName
            };

            var result = this.studentsRepository.Add(student);

            Assert.IsTrue(result.StudentId > 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void Add_WhenNameIsInvalid_ShouldNotAddToDatabase()
        {
            string studentName = null;
            Student student = new Student
            {
                FirstName = studentName,
                LastName = studentName
            };

            var result = this.studentsRepository.Add(student);
        }

        [TestMethod]
        public void Get_WhenIdIsValid()
        {
            string studentName = "PEsho";
            Student student = new Student
            {
                FirstName = studentName,
                LastName = studentName
            };

            var id = this.studentsRepository.Add(student).StudentId;

            var result = this.studentsRepository.Get(id);
            Assert.IsNotNull(result);
            Assert.AreEqual(studentName, result.FirstName);
        }

        [TestMethod]
        public void Get_WhenIdIsInvalid()
        {
            string studentName = "PEsho";
            Student student = new Student
            {
                FirstName = studentName,
                LastName = studentName
            };

            var id = this.studentsRepository.Add(student).StudentId;

            var result = this.studentsRepository.Get(id + 1);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetAll()
        {
            int oldCount = this.studentsRepository.All().Count();
            string studentName = "PEsho";
            Student student = new Student
            {
                FirstName = studentName,
                LastName = studentName
            };

            var id = this.studentsRepository.Add(student).StudentId;

            int countAfterAddition = this.studentsRepository.All().Count();

            Assert.IsTrue(countAfterAddition > 0);
            Assert.IsTrue(countAfterAddition > oldCount);
        }
    }
}
