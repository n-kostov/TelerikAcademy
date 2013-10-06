using Movies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Movies.ViewModels
{
    public class ActorViewModel
    {
        public static Expression<Func<Actor, ActorViewModel>> FromActor
        {
            get
            {
                return actor => new ActorViewModel
                {
                    ActorId = actor.ActorId,
                    Age = actor.Age,
                    Name = actor.Name,
                    IsMale = actor.IsMale
                };
            }
        }
        public int ActorId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public bool IsMale { get; set; }
        [Range(0, 120)]
        public int Age { get; set; }
    }
}