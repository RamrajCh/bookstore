namespace BookStore.Client.Services.BookServices
{
    public interface IBookService
    {
		List<Book> Books { get; set; }
		Task GetBooks();
		Task CreateBook(Book book);
		Task UpdateBook(Book book, int id);
		Task DeleteBook(int id);
	}
}
