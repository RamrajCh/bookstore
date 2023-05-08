namespace BookStore.Client.Services.BookServices
{
    public interface IBookServices
    {
        List<Book> Books { get; set; }
        List<Genre> Genres { get; set; }
        Task GetGenres();
        Task GetBooks();
    }
}
