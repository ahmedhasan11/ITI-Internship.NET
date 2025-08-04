using Movie_MVC_ConsumeAPI.Models;

namespace Movie_MVC_ConsumeAPI.Services
{
	public class MovieApiService
	{
		private readonly HttpClient _httpClient;

		public MovieApiService(IHttpClientFactory httpClient)
		{
			_httpClient = httpClient.CreateClient("MovieAPIClient");
		}

		public async Task<IEnumerable<Movie>> GetAllMovies()
		{
			return await _httpClient.GetFromJsonAsync<List<Movie>>("Movie");
		}

		public async Task<Movie> GetByID(int id)
		{
			return await _httpClient.GetFromJsonAsync<Movie>($"Movie/{id}");
		}

		public async Task<bool> Add(Movie movie)
		{
			var response= await _httpClient.PostAsJsonAsync("Movie",movie);
			return response.IsSuccessStatusCode;

		}
		public async Task<bool> Update(int id,Movie movie)
		{
			var reponse=await _httpClient.PutAsJsonAsync($"Movie/{id}", movie);
			return reponse.IsSuccessStatusCode;
		}
		public async Task<bool> Delete(int id)
		{
			var response=await _httpClient.DeleteAsync($"Movie/{id}");
			return response.IsSuccessStatusCode;

		}
	}
}
