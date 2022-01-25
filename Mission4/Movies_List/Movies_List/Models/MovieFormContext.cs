using System;
using Microsoft.EntityFrameworkCore;

namespace Movies_List.Models
{
       //This page sets up the connection between the database the the project
    public class MovieFormContext : DbContext 
    {
       public MovieFormContext(DbContextOptions<MovieFormContext> options): base (options)
       {
            // Leave Blank for now
       }
        public DbSet<NewMovieForm> Response { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<NewMovieForm>().HasData(

                new NewMovieForm
                {
                    MovieId = 1,
                    Category = "Action",
                    Title = "Avengers End Game",
                    Year = "2019",
                    Director = "Anthony Russo",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = "Super good, but there were a few things it was missing"
                },
                new NewMovieForm
                {
                    MovieId = 2,
                    Category = "Action",
                    Title = "Spider-Man No Way Home",
                    Year = "2021",
                    Director = "Jon Watts",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "Jake Pingree",
                    Notes = "Super good"
                },
                new NewMovieForm
                {
                    MovieId = 3,
                    Category = "Comedy",
                    Title = "Jungle Cruise",
                    Year = "2021",
                    Director = "Jaume Collet-Serra",
                    Rating = "PG-13",
                    Edited = true,
                    LentTo = "",
                    Notes = ""
                }
                );
        }
    }
}
