using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using MvcMovie.Data;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Documentary",
                        Rating = "G",
                        Price = 7.99M
                    },

                    new Movie
                    {
                        Title = "The Book of Mormon Movie ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Non-Fiction",
                        Rating = "G",
                        Price = 8.99M
                    },

                    new Movie
                    {
                        Title = "The Single's Ward",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Rating = "G",
                        Price = 9.99M
                    },

                    new Movie
                    {
                        Title = "The Other Side of Heaven",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "G",
                        Price = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
