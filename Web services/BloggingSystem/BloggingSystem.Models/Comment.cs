using System;

namespace BloggingSystem.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User User { get; set; }

        public DateTime PostDate { get; set; }

        public virtual Post Post { get; set; }
    }
}
