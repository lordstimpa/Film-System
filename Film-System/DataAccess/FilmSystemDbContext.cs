using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmSystem.DataAccess
{
    public class FilmSystemDbContext : DbContext
    {
        public DbSet<Models.Person> Person { get; set; }
        public DbSet<Models.Genre> Genre { get; set; }
        public DbSet<Models.PersonGenre> PersonGenre { get; set; }
        public DbSet<Models.Movie> Movie { get; set; }
        public DbSet<Models.MovieGenre> MovieGenre { get; set; }
        public DbSet<Models.MovieRating> MovieRating { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // DESKTOP connection string
            // optionsBuilder.UseSqlServer("Data Source=DESKTOP-Q2LT895; Initial Catalog=FilmSystem; Integrated Security=true");

            // LAPTOP connection string
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-HPC3BVL; Initial Catalog=FilmSystem; Integrated Security=true");
        }
    }
}