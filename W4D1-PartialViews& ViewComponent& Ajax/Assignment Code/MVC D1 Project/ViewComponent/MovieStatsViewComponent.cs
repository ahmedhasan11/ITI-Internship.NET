using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MVC_D1_Project.Data;
using MVC_D1_Project.Models;

namespace MVC_D1_Project.ViewComponents
{
	public class MovieStatsViewComponent:ViewComponent
	{
		private readonly IRepository<Movie> _movieRepository;

		public MovieStatsViewComponent(IRepository<Movie> movirerepo)
		{
			_movieRepository = movirerepo;
		}

		public IViewComponentResult Invoke()
		{
			var movies = _movieRepository.GetAll();
			var numberofmovies = movies.Count();
			var average_year = (int)movies.Average(m => m.ReleaseYear);
			var model = new MoviestatsViewModel
			{
				TotalMovies = numberofmovies,
				AverageYear = average_year
			};
			return View(model);

		}
	}
}
