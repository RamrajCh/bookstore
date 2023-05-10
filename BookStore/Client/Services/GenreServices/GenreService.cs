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
            await _http.PostAsJsonAsync("api/genres", genre);
        }

        public async Task DeleteGenre(int id)
        {
            await _http.DeleteAsync($"api/genres/{id}");
        }

        public async Task GetGenres()
        {
            var result = await _http.GetFromJsonAsync<List<Genre>>("api/genres");
            if (result != null)
                Genres = result;
        }

        public Task<Genre> GetSingleGenre(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGenre(Genre genre, int id)
        {
            await _http.PutAsJsonAsync($"api/genres/{id}", genre);
        }
    }
}
