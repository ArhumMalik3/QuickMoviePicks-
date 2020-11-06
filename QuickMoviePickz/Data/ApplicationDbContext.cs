using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickMoviePickz.Models;

namespace QuickMoviePickz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
            .HasData(
            new IdentityRole
            {
                Name = "MovieWatcher",
                NormalizedName = "MOVIEWATCHER"
            }
            );

            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 1,
                   NetflixId = 180,
                   Genre = "Sports Documentaries",

               }


           );

            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 2,
                   NetflixId = 1096,
                   Genre = "Biographical Movies",

               }


           );


            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 3,
                   NetflixId = 1402,
                   Genre = "Late Night Comedies",

               }


           );


            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 4,
                   NetflixId = 1492,
                   Genre = "Sci-Fi & Fantasy",

               }


           );

            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 5,
                   NetflixId = 2595,
                   Genre = "Science & Nature Docs",

               }


           );

            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 6,
                   NetflixId = 3979,
                   Genre = "Critically Acclaimed Films",

               }


           );


            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 7,
                   NetflixId = 4370,
                   Genre = "Sports Films",

               }


           );



            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 8,
                   NetflixId = 5756,
                   Genre = "Raunchy Comedies",

               }


           );


            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 9,
                   NetflixId = 5763,
                   Genre = "Drama",

               }


           );


            builder.Entity<GenreId>().HasData(
               new GenreId
               {
                   Id = 10,
                   NetflixId = 5284,
                   Genre = "Crime Films",

               }


           );



        }

       

        public DbSet<MovieWatcher> MovieWatchers { get; set; }

        public DbSet<PrivateGroup> PrivateGroups { get; set; }

        public DbSet<Questionnaire> Questionnaires { get; set; }

        public DbSet<MovieRanking> MovieRankings { get; set; }

        public DbSet<GenreId> Genres { get; set; }
    }
}
