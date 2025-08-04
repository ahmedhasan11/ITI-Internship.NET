using Microsoft.EntityFrameworkCore;
using MovieAPI.Models;

namespace MovieAPI.Data
{
	public interface IRepository<T> where T : class
	{
		Task<IEnumerable<T>> GetAllAsync();
		Task<T> GetByIDAsync(int id);
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(T entity);


	}

	public class MovieRepository : IRepository<Movie>
	{
		private readonly MovieContext _context;
		public MovieRepository(MovieContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Movie>> GetAllAsync()
		{
			return await _context.Movies.ToListAsync();
		}

		public async Task<Movie> GetByIDAsync(int id)
		{
			return await _context.Movies.FindAsync(id);
		}
		public async Task AddAsync(Movie movie)
		{
			await _context.Movies.AddAsync(movie);
		await _context.SaveChangesAsync();
		}
		public async Task UpdateAsync(Movie movie)
		{
			_context.Movies.Update(movie);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(Movie movie)
		{
			_context.Movies.Remove(movie);
			await _context.SaveChangesAsync();
		}


	}
}
