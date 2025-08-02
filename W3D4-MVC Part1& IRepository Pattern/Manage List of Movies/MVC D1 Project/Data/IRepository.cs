using Microsoft.AspNetCore.Http.HttpResults;
using MVC_D1_Project.Models;

namespace MVC_D1_Project.Data
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();

		T GetById(int id);

	}
	
	public class Repository : IRepository<Movie>
	{
		private static List<Movie> _MovieList = new List<Movie>()
			{
			new Movie {ID=1, Title="interstellar",Director="chris"},
			new Movie{ID=2, Title="inception",Director="chris"},
			new Movie { ID=3, Title="the dark knight",Director="chris"}

			};

		public IEnumerable<Movie> GetAll()
		{
			return _MovieList;
		}

		public Movie GetById(int id)
		{
			var Movie = _MovieList.FirstOrDefault(m=>m.ID==id);
			if (Movie != null)
			{
				return Movie;
			}
			else
			{
				return null;
			}

		}

		//IEnumerable<Movie> GetAll()
		//{
		//	return _MovieList;
		//}
		//}

		//Movie GetByID(int id)
		//{
		//	var movie = _MovieList.FirstOrDefault(m => m.ID == id)
		//if (movie != null)
		//	{
		//		Console.WriteLine();
		//	}
		//}


	}   }
