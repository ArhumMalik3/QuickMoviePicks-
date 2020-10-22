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
                Name = "Movie Watcher",
                NormalizedName = "MOVIEWATCHER"
            }
            );
        }

        public DbSet<MovieWatcher> MovieWatchers { get; set; }

        public DbSet<PrivateGroup> PrivateGroups { get; set; }

        public DbSet<Questionnaire> Questionnaires { get; set; }
    }
}
