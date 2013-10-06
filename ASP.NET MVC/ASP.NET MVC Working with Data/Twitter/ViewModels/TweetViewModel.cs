using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.ViewModels
{
    public class TweetViewModel
    {
        public int TweetId { get; set; }

        [Required]
        [StringLength(250)]
        public string Content { get; set; }
        public DateTime CretedOn { get; set; }
        [Required]
        public string Author { get; set; }

        public IEnumerable<string> Tags { get; set; }
    }
}