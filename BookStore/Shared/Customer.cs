using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string? Name { get; set; }
		[Required]
		public string? PhoneNumber { get; set; }
	}
}
