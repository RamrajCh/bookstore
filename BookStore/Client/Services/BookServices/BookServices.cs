using System.Net.Http.Json;

namespace BookStore.Client.Services.BookServices
{
    public class BookServices : IBookServices
    {
        private readonly HttpClient _http;

        public BookServices(HttpClient http)
        {
            _http = http;
        }

        public List<Book> Books { get; set; } = new List<Book>();
        public List<Genre> Genres { get; set; } = new List<Genre>();

        public async Task GetBooks()
        {
            var result = await _http.GetFromJsonAsync<List<Book>>("api/book/getbooks");
            if (result != null) Books = result;
        }

        public async Task GetGenres()
        {
            var result = await _http.GetFromJsonAsync<List<Genre>>("api/book/getgenres");
            if (result != null) Genres = result;
        }
    }
}
