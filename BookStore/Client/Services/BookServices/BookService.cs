using BookStore.Client.Pages;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace BookStore.Client.Services.BookServices
{
	public class BookService : IBookService
	{
		private readonly HttpClient _http;

		public BookService(HttpClient http)
        {
			_http = http;
		}
        public List<Book> Books { get; set; } = new List<Book>();

		public async Task CreateBook(Book book)
		{
			var result = await _http.PostAsJsonAsync("api/books", book);
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception("Error in creating new book!!");
			}
		}

		public async Task DeleteBook(int id)
		{
			var result = await _http.DeleteAsync($"api/books/{id}");
			if (!result.IsSuccessStatusCode)
			{
				throw new Exception("Error in deleting book!!");
			}
		}

		public async Task GetBooks()
		{
			var result = await _http.GetFromJsonAsync<List<Book>>("api/books");
			if (result != null)
				Books = result;
		}

		public async Task UpdateBook(Book book, int id)
		{
			var result = await _http.PutAsJsonAsync($"api/books/{id}", book);
			if (! result.IsSuccessStatusCode)
			{
				throw new Exception("Error in updating book!!");
			}
		}
	}
}
