using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data
{
	public class MovieContext:DbContext
	{
		public DbSet<Movie> Movies { get; set; }
		public MovieContext(DbContextOptions<MovieContext> options) :base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Movie>().HasData(
			
				new Movie { ID = 1, Title = "interstellar", Director = "chris" },
				new Movie { ID = 2, Title = "inception", Director = "chris" },
				new Movie { ID = 3, Title = "the dark knight", Director = "chris" }
			);

			base.OnModelCreating(modelBuilder);
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-6N5TH8D\\SQLEXPRESS;Integrated Security=True;Trust Server Certificate=True");
			base.OnConfiguring(optionsBuilder);
		}
	}
}
