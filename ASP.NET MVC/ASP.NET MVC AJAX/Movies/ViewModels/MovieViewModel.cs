using Movies.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Movies.ViewModels
{
    public class MovieViewModel
    {
        public static Expression<Func<Movie, MovieViewModel>> FromMovie
        {
            get
            {
                return movie => new MovieViewModel
                {
                    MovieId = movie.MovieId,
                    Director = movie.Director,
                    Title = movie.Title,
                    Studio = movie.Studio,
                    Year = movie.Year,
                    StudioAddress = movie.StudioAddress,
                    LeadingMaleActor = new ActorViewModel()
                    {
                        ActorId = movie.LeadingMaleActor.ActorId,
                        Age = movie.LeadingMaleActor.Age,
                        IsMale = movie.LeadingMaleActor.IsMale,
                        Name = movie.LeadingMaleActor.Name
                    },
                    LeadingFemaleActor = new ActorViewModel()
                    {
                        ActorId = movie.LeadingFemaleActor.ActorId,
                        Age = movie.LeadingFemaleActor.Age,
                        IsMale = movie.LeadingFemaleActor.IsMale,
                        Name = movie.LeadingFemaleActor.Name
                    }
                };
            }
        }
        public int MovieId { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Director { get; set; }

        public DateTime? Year { get; set; }
        public ActorViewModel LeadingMaleActor { get; set; }
        public ActorViewModel LeadingFemaleActor { get; set; }

        [StringLength(50)]
        public string Studio { get; set; }

        [StringLength(50)]
        public string StudioAddress { get; set; }
    }
}