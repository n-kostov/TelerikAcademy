using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsMale { get; set; }
        [Range(0, 120)]
        public int Age { get; set; }
    }
}