using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Twitter.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {

    }

    public class Tweet
    {
        public int TweetId { get; set; }

        [Required]
        [StringLength(250)]
        public string Content { get; set; }
        public DateTime CretedOn { get; set; }

        [Required]
        [ForeignKey("Author")]
        public string AuhorId { get; set; }

        public virtual User Author { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContextWithCustomUser<User>
    {
        public DbSet<Tweet> Tweets { get; set; }
    }
}