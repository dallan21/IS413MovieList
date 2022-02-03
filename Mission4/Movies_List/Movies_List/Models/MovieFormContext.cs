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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(

                new Category { CategoryId=1 , CategoryName= "Action/Adventure"},
                new Category { CategoryId =2 , CategoryName = "Comedy" },
                new Category { CategoryId =3 , CategoryName = "Drama" },
                new Category { CategoryId =4, CategoryName = "Family" },
                new Category { CategoryId =5 , CategoryName = "Horror/Suspense" },
                new Category { CategoryId =6 , CategoryName = "Miscellaneous" },
                new Category { CategoryId =7, CategoryName = "Television" },
                new Category { CategoryId =8, CategoryName = "VHS" }
                );





            mb.Entity<NewMovieForm>().HasData(

                new NewMovieForm
                {
                    MovieId = 1,
                    CategoryId = 1,
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
                    CategoryId = 1,
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
                    CategoryId = 2,
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

        internal dynamic ToList()
        {
            throw new NotImplementedException();
        }
    }
}
