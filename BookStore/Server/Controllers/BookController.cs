using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static readonly List<Genre> genres = new List<Genre>
        {
            new Genre
            {
                GenreId = 1,
                Name = "Fiction"
            },
            new Genre
            {
                GenreId = 2,
                Name = "Fantasy"
            }
        };

        private static readonly List<Book> books = new List<Book>
        {
            new Book
            {
                BookId = 1,
                Title = "The Kite Runner",
                Author = "Khaled Hosseini",
                IsbnNumber = "978-1-4088-5025-1",
                PublishedYear = new DateTime(2003, 04,04),
                Price = (decimal)(499 * 1.6),
                Stock = 3,
                Genre = genres[0],
                GenreId = 1
            },
            new Book
            {
                BookId = 2,
                Title = "A Game of Thrones",
                Author = "George R.R. Martin",
                IsbnNumber = "978-0-553-10354-7",
                PublishedYear = new DateTime(1996,03,02),
                Price = (decimal)(873 * 1.6),
                Stock = 2,
                Genre = genres[1],
                GenreId = 2
            }
        };

        [HttpGet("getbooks")]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("getgenres")]
        public async Task<ActionResult<List<Book>>> Getgenres()
        {
            return Ok(genres);
        }

    }
}
