using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared
{
	public class Book
	{
		public int BookId { get; set; }
		public string? Title { get; set; }
		public string? Author { get; set; }
		public string? ISBN { get; set; }
		public DateTime PublishedYear { get; set; }
		[Column(TypeName = "decimal(7,2)")]
		public decimal Price { get; set; }
		public int Stock { get; set; }
		public Genre? Genre { get; set; }
		public int GenreId { get; set; }

	}
}
