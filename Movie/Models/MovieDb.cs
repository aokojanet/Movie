using Microsoft.EntityFrameworkCore;

namespace Movie.Models
{
	public class MovieDb : DbContext
	{ 
		public MovieDb( DbContextOptions <MovieDb> options) : base(options)
		{ 

		}
		
			protected override void OnModelCreating(ModelBuilder modelBuilder)
			{
				modelBuilder.Entity<Rating>()
					.HasOne(r => r.User) 
					.WithOne(u => u.Rating) 
					.HasForeignKey<Rating>(r => r.UsersId); 
			}

		public DbSet<Actors> Actors { get; set; }
		public DbSet<Category> Category  { get; set; }
		public DbSet<Rating> Rating   { get; set; }
		public DbSet<Movies> Movies   { get; set; }

	}
}
