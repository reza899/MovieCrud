using Microsoft.EntityFrameworkCore;
using MovieCrud.Models;

namespace MovieCrud.Data
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> option) : base(option)
        {
        }
        public DbSet<Movie> Movies { get; set; }
    }

}