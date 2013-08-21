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
    public class PostControllerTests
    {
        private static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(PostsController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {                
                new Route(
                    "UsersApi",
                    "api/users/{action}",
                    new
                    {
                        controller = "users"
                    }),
                new Route(
                    "PostsApi",
                    "api/posts/{postId}/comment",
                    new
                    {
                        controller = "posts",
                        action = "comment"
                    }),
                new Route(
                    "DefaultApi",
                    "api/posts",
                    new 
                    { 
                        controller = "posts" 
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
        public void CreatePost_WhenCreatingPostModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "Someone got me",
                Tags = new List<string>()
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postModel = this.RegisterTestPost(this.httpServer, headers, testPost);

            Assert.AreEqual(testPost.Title, postModel.Title);
            Assert.IsTrue(postModel.Id > 0);
        }

        [TestMethod]
        public void CreatePost_WhenCreatingPostModelInValidSessionKey_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "Someone got me",
                Tags = new List<string>()
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = new string('z', 50);
            var response = this.httpServer.Post("api/posts", testPost, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePost_WhenCreatingPostModelMissingText_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Tags = new List<string>()
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = this.httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePost_WhenCreatingPostModelMissingTitle_ShouldNotSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Text = "dsfafdasfa",
                Tags = new List<string>()
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = this.httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void GetPostsByTags_ShouldReturnStatusCode200AndNotNullContent()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "I wanna go home",
                Tags = new List<string>() { "home", "go", "i" }
            };

            var testPost2 = new CreatingPostModel()
            {
                Title = "I will",
                Text = "Go home",
                Tags = new List<string>() { "home", "go" }
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postModel1 = this.RegisterTestPost(this.httpServer, headers, testPost);
            var postModel2 = this.RegisterTestPost(this.httpServer, headers, testPost2);

            var response = this.httpServer.Get("api/posts?tags=home,go", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<List<PostModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(2, model.Count);
        }

        [TestMethod]
        public void GetPostsByTags_ShouldReturnStatusCode200AndNotNullContent_1Of2()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "I wanna go home",
                Tags = new List<string>() { "home", "go", "i" }
            };

            var testPost2 = new CreatingPostModel()
            {
                Title = "I will",
                Text = "Go home",
                Tags = new List<string>() { "home", "go" }
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postModel1 = this.RegisterTestPost(this.httpServer, headers, testPost);
            var postModel2 = this.RegisterTestPost(this.httpServer, headers, testPost2);

            var response = this.httpServer.Get("api/posts?tags=home,will", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<List<PostModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(1, model.Count);
        }

        [TestMethod]
        public void GetPostsByTags_ShouldReturnStatusCode200AndNoContent_ExistingTags()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "I wanna go home",
                Tags = new List<string>() { "home", "go", "i" }
            };

            var testPost2 = new CreatingPostModel()
            {
                Title = "I will",
                Text = "Go home",
                Tags = new List<string>() { "home", "go" }
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postModel1 = this.RegisterTestPost(this.httpServer, headers, testPost);
            var postModel2 = this.RegisterTestPost(this.httpServer, headers, testPost2);

            var response = this.httpServer.Get("api/posts?tags=dsfafdasfa,will", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<List<PostModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(0, model.Count);
        }

        [TestMethod]
        public void GetPostsByTags_ShouldReturnStatusCode200AndNoContent_NonExistingTags()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "I wanna go home",
                Tags = new List<string>() { "home", "go", "i" }
            };

            var testPost2 = new CreatingPostModel()
            {
                Title = "I will",
                Text = "Go home",
                Tags = new List<string>() { "home", "go" }
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postModel1 = this.RegisterTestPost(this.httpServer, headers, testPost);
            var postModel2 = this.RegisterTestPost(this.httpServer, headers, testPost2);

            var response = this.httpServer.Get("api/posts?tags=pesho,gosho", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var model = JsonConvert.DeserializeObject<List<PostModel>>(contentString);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(0, model.Count);
        }

        [TestMethod]
        public void PutCommentInPost_ShouldReturnStatusCode200()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "I wanna go home",
                Tags = new List<string>() { "home", "go", "i" }
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postModel1 = this.RegisterTestPost(this.httpServer, headers, testPost);

            var response = this.httpServer.Put("api/posts/" + postModel1.Id + "/comment", "I really wanna go home", headers);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void PutCommentInPost_InvalidPostId_ShouldReturnStatusCode400()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "I wanna go home",
                Tags = new List<string>() { "home", "go", "i" }
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postModel1 = this.RegisterTestPost(this.httpServer, headers, testPost);

            var response = this.httpServer.Put("api/posts/0/comment", "I really wanna go home", headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PutCommentInPost_NullText_ShouldReturnStatusCode400()
        {
            var testUser = new UserModel()
            {
                Username = "dsfafdasfa",
                DisplayName = "Someone",
                AuthCode = new string('b', 40)
            };

            var userModel = this.RegisterTestUser(this.httpServer, testUser);

            var testPost = new CreatingPostModel()
            {
                Title = "dsfafdasfa",
                Text = "I wanna go home",
                Tags = new List<string>() { "home", "go", "i" }
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var postModel1 = this.RegisterTestPost(this.httpServer, headers, testPost);

            var response = this.httpServer.Put("api/posts/0/comment", null, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private CreatedPostModel RegisterTestPost(
            InMemoryHttpServer httpServer,
            Dictionary<string, string> headers,
            CreatingPostModel testPost)
        {
            var response = this.httpServer.Post("api/posts", testPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var postModel = JsonConvert.DeserializeObject<CreatedPostModel>(contentString);
            return postModel;
        }

        private LoggedUserModel RegisterTestUser(InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            return userModel;
        }
    }
}
