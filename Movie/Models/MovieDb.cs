using Microsoft.EntityFrameworkCore;

namespace Movie.Models
{
	public class MovieDb : DbContext
	{ 
		public MovieDb( DbContextOptions <MovieDb> options) : base(options)
		{ 

		}
		public DbSet<Actors> Actors { get; set; }
		public DbSet<Category> Category  { get; set; }
		public DbSet<Rating> Rating   { get; set; }
		public DbSet<Movies> Movies   { get; set; }

	}
}
