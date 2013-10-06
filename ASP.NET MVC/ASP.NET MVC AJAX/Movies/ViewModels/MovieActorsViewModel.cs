using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Movies.ViewModels
{
    public class MovieActorsViewModel
    {
        public MovieViewModel Movie { get; set; }
        public IEnumerable<ActorViewModel> Actors { get; set; }
    }
}