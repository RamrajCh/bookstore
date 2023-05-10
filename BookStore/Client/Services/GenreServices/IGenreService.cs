namespace BookStore.Client.Services.GenreServices
{
    public interface IGenreService
    {
        List<Genre> Genres { get; set; }
        Task GetGenres();
        Task CreateGenre(Genre genre);
        Task UpdateGenre(Genre genre, int id);
        Task DeleteGenre(int id);

    }
}
