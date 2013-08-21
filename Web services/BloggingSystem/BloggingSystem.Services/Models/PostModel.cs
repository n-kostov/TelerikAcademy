using BloggingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace BloggingSystem.Services.Models
{
    public class PostModel
    {
        public static Expression<Func<Post, PostModel>> FromPost
        {
            get
            {
                return x => new PostModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    PostedBy = x.User.Nickname,
                    PostDate = x.PostDate,
                    Text = x.Content,
                    Tags = (from tagEntity in x.Tags
                            select tagEntity.Name),
                    Comments = (from commentEntity in x.Comments
                                select new CommentModel
                                {
                                    Text = commentEntity.Content,
                                    CommentedBy = commentEntity.User.Nickname,
                                    PostDate = commentEntity.PostDate
                                })
                };
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostDate { get; set; }
        public string Text { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<CommentModel> Comments { get; set; }
    }
}