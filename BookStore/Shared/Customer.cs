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
		[RegularExpression(@"^9(8|7)[0-9]{8}$", ErrorMessage ="Please provide valid phone number.")]
		public string? PhoneNumber { get; set; }
	}
}
