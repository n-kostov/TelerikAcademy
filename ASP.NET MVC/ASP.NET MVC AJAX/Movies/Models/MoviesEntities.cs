using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Movies.Models
{
    public class MoviesEntities : DbContext
    {
        public MoviesEntities()
            : base("MoviesDb")
        {

        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasRequired(x => x.LeadingMaleActor)
                .WithMany().HasForeignKey(x => x.LeadingMaleActorId).WillCascadeOnDelete(false);

            modelBuilder.Entity<Movie>().HasRequired(x => x.LeadingFemaleActor)
                .WithMany().HasForeignKey(x => x.LeadingFemaleActorId).WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}