using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using BloggingSystem.Data;
using BloggingSystem.Services.Attributes;
using BloggingSystem.Services.Models;

namespace BloggingSystem.Services.Controllers
{
    public class TagsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<TagModel> GetAll(
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

                var tagEntities = context.Tags;
                var models =
                     from tagEntity in tagEntities
                     select new TagModel()
                     {
                         Id = tagEntity.Id,
                         Name = tagEntity.Name,
                         Posts = context.Posts.Where(t => t.Tags.Any(tag => tag.Name == tagEntity.Name)).Count()
                     };

                return models.OrderBy(t => t.Id);
            });

            return responseMsg;
        }

        [ActionName("posts")]
        public IQueryable<PostModel> GetPostsByTag(
            int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
              {
                  var context = new BloggingSystemContext();
                  using (context)
                  {
                      var user = context.Users.FirstOrDefault(u => u.SessionKey == sessionKey);
                      if (user == null)
                      {
                          throw new ArgumentOutOfRangeException("Invalid session key!");
                      }

                      var tag = context.Tags.Include("Posts").Include("Posts.Tags").Include("Posts.Comments")
                          .FirstOrDefault(t => t.Id == tagId);
                      if (tag == null)
                      {
                          throw new ArgumentOutOfRangeException("tagId", "Invalid tag");
                      }

                      var postsEntities = tag.Posts;
                      /*
                      var models = (from postEntity in postsEntities
                                    select new PostModel
                                    {
                                        Id = postEntity.Id,
                                        Title = postEntity.Title,
                                        PostedBy = postEntity.User.Nickname,
                                        PostDate = postEntity.PostDate,
                                        Text = postEntity.Content,
                                        Tags = (from tagEntity in postEntity.Tags
                                                select tagEntity.Name),
                                        Comments = (from commentEntity in postEntity.Comments
                                                    select new CommentModel
                                                    {
                                                        Text = commentEntity.Content,
                                                        CommentedBy = commentEntity.User.Nickname,
                                                        PostDate = commentEntity.PostDate
                                                    })
                                    }).AsQueryable();
                       */
                      var models = postsEntities.AsQueryable().Select(PostModel.FromPost);

                      return models.OrderByDescending(p => p.PostDate);
                  }
              });

            return responseMsg;
        }
    }
}
