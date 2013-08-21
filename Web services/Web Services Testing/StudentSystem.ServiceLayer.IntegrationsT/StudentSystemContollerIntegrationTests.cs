using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using StudentSystem.RepositoryLayer;
using System.Collections.Generic;
using StudentSystem.Model;
using System.Net;
using StudentSystem.ServiceLayer.Models;

namespace StudentSystem.ServiceLayer.IntegrationsT
{
    [TestClass]
    public class StudentSystemContollerIntegrationTests
    {
        [TestMethod]
        public void GetAll_WhenOneStudent_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            IList<Student> models = new List<Student>();
            models.Add(new Student()
            {
                FirstName = "PEsho",
                LastName = "Gosho"
            });

            Mock.Arrange(() => mockRepository.All())
                .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void Get_WhenOneStudent_ShouldReturnStatusCode500()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            IList<Student> models = new List<Student>();
            models.Add(new Student()
            {
                FirstName = "PEsho",
                LastName = "Gosho"
            });

            //Mock.Arrange(() => mockRepository.Get(Arg.AnyInt))
            //    .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students/0");

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void Get_WhenOneStudent_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            IList<Student> models = new List<Student>();
            Student stundent1 = new Student()
            {
                FirstName = "PEsho",
                LastName = "Gosho",
                StudentId = 1
            };

            Student student2 = new Student
            {
                FirstName = "fas",
                LastName = "dga",
                StudentId = 2
            };

            models.Add(stundent1);
            models.Add(student2);

            Mock.Arrange(() => mockRepository.Get(Arg.Matches<int>(x => x == 1)))
                .Returns(() => stundent1);

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/students/1");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void PostStudent_WhenNameIsNull_ShouldReturnStatusCode400()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Mock.Arrange(() => mockRepository
                .Add(Arg.Matches<Student>(st => st.FirstName == null)))
                    .Throws<NullReferenceException>();

            var server =
                new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var response = server.CreatePostRequest("api/students",
                new StudentModel()
                {
                    FirstName = null
                });

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void PostStudent_WhenNameIsValid_ShouldReturnStatusCode204()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();

            Student student = new Student
            {
                FirstName = "Pesho",
                LastName = "Gosho"
            };

            Mock.Arrange(() => mockRepository
                .Add(Arg.IsAny<Student>()))
                .Returns(() => student);

            var server =
                new InMemoryHttpServer<Student>("http://localhost/", mockRepository);

            var response = server.CreatePostRequest("api/students",
                new StudentModel()
                {
                    FirstName = "Pesho",
                    LastName = "Gosho"
                });

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }
    }
}
