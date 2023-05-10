using Telerik.SvgIcons;

namespace BookStore.Server.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Customer>(entity => {
				entity.HasIndex(c => c.PhoneNumber).IsUnique();
			});
		}

		public DbSet<Shared.Book> Books{ get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Sale> Sales { get; set; }
		public DbSet<SalesItem> SalesItems { get; set; }
	}
}
