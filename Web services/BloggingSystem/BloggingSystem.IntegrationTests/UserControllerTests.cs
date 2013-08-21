using System.Collections.Generic;
using System.Net;
using System.Transactions;
using BloggingSystem.Services.Controllers;
using BloggingSystem.Services.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace BloggingSystem.IntegrationTests
{
    [TestClass]
    public class UserControllerTests
    {
        private static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                "UsersApi",
                "api/users/{action}",
                new
                {
                    controller = "users"
                })
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var model = this.RegisterTestUser(this.httpServer, testUser);
            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]
        public void Register_WhenUserModelInValidUsername_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "INV",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_MissingUsername_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_MissingNickname_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_MissingAuthCode_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSR",
                DisplayName = "VALIDNICK"
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelInValidNickname_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Inv",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelInValidAuthCode_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 39)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenUserModelValidSessionKey_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var model = this.RegisterTestUser(this.httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = model.SessionKey;
            var response = this.httpServer.Put("api/users/logout", null, headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenUserModelInValidSessionKey_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var model = this.RegisterTestUser(this.httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = new string('z', 50);
            var response = this.httpServer.Put("api/users/logout", null, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private LoggedUserModel RegisterTestUser(InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            return userModel;
        }
    }
}
