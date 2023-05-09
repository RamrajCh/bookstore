namespace BookStore.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		

		public DbSet<Book> Books{ get; set; }
		public DbSet<Genre> Genres { get; set; }


	}
}
