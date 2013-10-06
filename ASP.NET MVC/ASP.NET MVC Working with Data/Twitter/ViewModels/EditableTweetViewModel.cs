using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Twitter.ViewModels
{
    public class EditableTweetViewModel
    {
        public int TweetId { get; set; }

        [Required]
        [StringLength(250)]
        public string Content { get; set; }
    }
}