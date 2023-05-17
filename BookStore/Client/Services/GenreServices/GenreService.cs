using System.Net.Http.Json;

namespace BookStore.Client.Services.GenreServices
{
    public class GenreService : IGenreService
    {
        private readonly HttpClient _http;

        public GenreService(HttpClient http)
        {
            _http = http;
        }

		public List<Genre> Genres { get; set; } = new List<Genre>();

        public async Task CreateGenre(Genre genre)
		{
            var result = await _http.PostAsJsonAsync("api/genres", genre);
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception("Error in creating genre!");
			}
		}

        public async Task DeleteGenre(int id)
        {
            var result = await _http.DeleteAsync($"api/genres/{id}");
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception("Error in deleting genre!");
			}
		}

        public async Task GetGenres()
        {
            var result = await _http.GetFromJsonAsync<List<Genre>>("api/genres");
            if (result != null)
                Genres = result;
        }

        public async Task UpdateGenre(Genre genre, int id)
        {
            var result = await _http.PutAsJsonAsync($"api/genres/{id}", genre);
            if (!result.IsSuccessStatusCode)
            {
                throw new Exception("Error in updating genre");
            }
        }
    }
}
