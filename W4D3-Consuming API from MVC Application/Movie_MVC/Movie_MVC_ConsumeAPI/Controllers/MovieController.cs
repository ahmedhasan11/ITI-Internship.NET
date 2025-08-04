using Microsoft.AspNetCore.Mvc;
using Movie_MVC_ConsumeAPI.Models;
using Movie_MVC_ConsumeAPI.Services;
using System.Threading.Tasks;
///////////MVC
namespace Movie_MVC_ConsumeAPI.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieApiService _api;
        public MovieController(MovieApiService movieapi)
        {
            _api = movieapi;
        }
        public async Task<IActionResult> Index()
        {
            var movies=await _api.GetAllMovies();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
           var movie=await _api.GetByID(id);
            return View(movie);
		}
		[HttpGet]
		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Movie movie)
		{
			if (!ModelState.IsValid)
				return View(movie);

			await _api.Add(movie);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public async Task<IActionResult> Update(int id)
		{
			var movie = await _api.GetByID(id);
			if (movie == null)
				return NotFound();

			return View(movie);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task< IActionResult> Update( int id , Movie movie)
		{
			if (id != movie.ID)
				return BadRequest();

			if (!ModelState.IsValid)
				return View(movie);

			await _api.Update(id, movie);
			return RedirectToAction(nameof(Index));
		}
		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var movie = await _api.GetByID(id);
			if (movie == null)
				return NotFound();

			return View(movie);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirm(int id)
		{
			await _api.Delete(id);
			return RedirectToAction(nameof(Index));
		}
	}
}
