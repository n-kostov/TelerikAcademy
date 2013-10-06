using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }
        [StringLength(50)]
        public string Director { get; set; }
        public DateTime? Year { get; set; }
        public int LeadingMaleActorId { get; set; }
        public int LeadingFemaleActorId { get; set; }
        public virtual Actor LeadingMaleActor { get; set; }
        public virtual Actor LeadingFemaleActor { get; set; }
        [StringLength(50)]
        public string Studio { get; set; }
        [StringLength(50)]
        public string StudioAddress { get; set; }
    }
}