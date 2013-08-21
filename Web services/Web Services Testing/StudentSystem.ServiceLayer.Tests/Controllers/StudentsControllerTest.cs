using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudentSystem.ServiceLayer;
using StudentSystem.ServiceLayer.Controllers;
using StudentSystem.ServiceLayer.Models;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using StudentSystem.Model;
using Telerik.JustMock;
using StudentSystem.RepositoryLayer;

namespace StudentSystem.ServiceLayer.Tests.Controllers
{
    [TestClass]
    public class StudentsControllerTest
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "students");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod]
        public void GetAllStudents()
        {
            var repository = Mock.Create<IRepository<Student>>();
            IList<Student> studentEntities = new List<Student>();
            Student student = new Student { FirstName = "PEsho", LastName = "Pest" };
            studentEntities.Add(student);
            Mock.Arrange(() => repository.All())
                .Returns(() => studentEntities.AsQueryable());

            var controller = new StudentsController(repository);

            var result = controller.Get();

            Assert.IsTrue(result.Count() == 1);
            Assert.AreEqual("PEsho", result.First().FirstName);
        }

        [TestMethod]
        public void GetStudentById()
        {
            // Arrange
            var repository = Mock.Create<IRepository<Student>>();

            IList<Student> studentEntities = new List<Student>();
            Student student = new Student { FirstName = "PEsho", LastName = "Gosho", StudentId = 5 };
            studentEntities.Add(student);
            Mock.Arrange(() => repository.Get(Arg.AnyInt))
                .Returns(() => student);

            StudentsController controller = new StudentsController(repository);
            SetupController(controller);
            // Act
            var result = controller.Get(5);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("PEsho", result.FirstName);
        }

        [TestMethod]
        public void PostStudent()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository<Student>>();

            var studentModel = new StudentModel()
            {
                FirstName = "Pesho",
                LastName = "Gosho"
            };
            var studentEntity = new Student()
            {
                FirstName = studentModel.FirstName,
                LastName = studentModel.LastName
            };
            Mock.Arrange(() => repository.Add(Arg.IsAny<Student>()))
                .DoInstead(() => isItemAdded = true)
                .Returns(() => studentEntity);

            var controller = new StudentsController(repository);
            SetupController(controller);

            controller.Post(studentModel);

            Assert.IsTrue(isItemAdded);
        }
    }
}