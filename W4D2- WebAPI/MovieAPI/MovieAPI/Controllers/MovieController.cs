using Microsoft.AspNetCore.Mvc;
using MovieAPI.Data;
using MovieAPI.Models;
using System.Threading.Tasks;
////////////////API
namespace MovieAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class MovieController : ControllerBase
    {
        private readonly IRepository<Movie> _movierepository;

        public MovieController(IRepository<Movie> movierepo)
        {
            _movierepository = movierepo;
        }
        [HttpGet]
		public async Task<IActionResult> Index() //show all movies
        {
            var movies = await _movierepository.GetAllAsync();

			return Ok(movies);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id) //return a specific movie
        {
            var movie = await _movierepository.GetByIDAsync(id);
            return Ok(movie);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync( [FromBody] Movie movie)
        {
           await _movierepository.AddAsync(movie);
			//await _movierepository.SaveChangesAsync();
			return CreatedAtAction(nameof(GetByID), new { id = movie.ID }, movie);
		}
        [HttpPut("{id}")]
		public async Task<IActionResult> EditAsync(int id, [FromBody] Movie movie)
		{
            if (id==movie.ID)
            {
				var existingmovie = await _movierepository.GetByIDAsync(id);
				if (existingmovie != null)
				{
					await _movierepository.UpdateAsync(movie);
					//await _movierepository.SaveChangesAsync();
					return NoContent();
				}
				else
				{
					return NotFound();
				}

			}
			else
			{
				return NotFound();
			}



		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var movie =await _movierepository.GetByIDAsync(id);
			if (movie == null)
				return NotFound();

			await _movierepository.DeleteAsync(movie);
			//await _movierepository.SaveChangesAsync();

			return NoContent();
		}
	}
}
