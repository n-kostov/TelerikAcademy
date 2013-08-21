using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Data;
using BloggingSystem.Models;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Models;

namespace BloggingSystem.Services.Controllers
{
    public class PostsController : BaseApiController
    {
        private char[] delimiters = { ' ', ',' };

        [HttpGet]
        public IQueryable<PostModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();

                var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                if (user == null)
                {
                    throw new InvalidOperationException("Invalid session key!");
                }

                var postsEntities = context.Posts;
                var models = postsEntities.Select(PostModel.FromPost);
                return models.OrderByDescending(tag => tag.PostDate);
            });

            return responseMsg;
        }

        public IQueryable<PostModel> GetPage(
            int page,
            int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Skip(page * count)
                .Take(count);
            return models;
        }

        public IQueryable<PostModel> GetByCategory(
            string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey)
                .Where(post => post.Title.Contains(keyword));
            return models;
        }

        public IQueryable<PostModel> GetByTags(
            string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var models = this.GetAll(sessionKey);
            string[] splitTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var tag in splitTags)
            {
                models = models.Where(t => t.Tags.Contains(tag));
            }

            return models;
        }

        public HttpResponseMessage PostCreatePost(
            CreatingPostModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
                () =>
                {
                    if (model.Title == null)
                    {
                        throw new ArgumentNullException("title", "The title cannot be null!");
                    }

                    if (model.Text == null)
                    {
                        throw new ArgumentNullException("text", "The text cannot be null!");
                    }

                    var context = new BloggingSystemContext();
                    using (context)
                    {
                        var user = context.Users.FirstOrDefault(usr => usr.SessionKey == sessionKey);
                        if (user == null)
                        {
                            throw new InvalidOperationException("Invalid session key!");
                        }

                        var post = new Post()
                        {
                            Title = model.Title,
                            Content = model.Text,
                            PostDate = DateTime.Now,
                            User = user,
                            Tags = (from tagEntity in model.Tags
                                    select (
                                        !context.Tags.Select(t => t.Name).Contains(tagEntity.ToLower())
                                        ? new Tag { Name = tagEntity.ToLower() }
                                        : context.Tags.First(t => t.Name == tagEntity.ToLower())))
                                        .ToList()
                        };

                        FindTagsInTitle(context, post);

                        context.Posts.Add(post);
                        context.SaveChanges();

                        var createdPostModel = new CreatedPostModel()
                        {
                            Id = post.Id,
                            Title = post.Title
                        };

                        var response =
                            this.Request.CreateResponse(HttpStatusCode.Created, createdPostModel);
                        return response;
                    }
                });

            return responseMsg;
        }

        [ActionName("comment")]
        public HttpResponseMessage PutLeaveAComment(
            int postId,
            [FromBody] string text,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(
              () =>
              {
                  if (text == null)
                  {
                      throw new ArgumentNullException("text", "The comment's text cannot be null!");
                  }

                  var context = new BloggingSystemContext();
                  using (context)
                  {
                      var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                      if (user == null)
                      {
                          throw new ArgumentOutOfRangeException("Invalid session key!");
                      }

                      var post = context.Posts.FirstOrDefault(p => p.Id == postId);
                      if (post == null)
                      {
                          throw new ArgumentOutOfRangeException("postId", "Invalid post");
                      }

                      var comment = new Comment
                      {
                          Content = text,
                          User = user,
                          PostDate = DateTime.Now,
                          Post = post
                      };

                      context.Comments.Add(comment);
                      context.SaveChanges();

                      var response =
                          this.Request.CreateResponse(HttpStatusCode.OK);
                      return response;
                  }
              });

            return responseMsg;
        }

        private void FindTagsInTitle(BloggingSystemContext context, Post post)
        {
            var titleTags = post.Title.Split(this.delimiters, StringSplitOptions.RemoveEmptyEntries);
            foreach (var titleTag in titleTags)
            {
                var tagToLower = titleTag.ToLower();
                bool postContainsTag = post.Tags.Select(t => t.Name).Contains(tagToLower);
                if (!postContainsTag && !context.Tags.Select(t => t.Name).Contains(tagToLower))
                {
                    post.Tags.Add(new Tag { Name = titleTag.ToLower() });
                }
                else if (!postContainsTag)
                {
                    post.Tags.Add(context.Tags.First(t => t.Name == tagToLower));
                }
            }
        }
    }
}
