using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared
{
    public class Sale
    {
        public int SaleId { get; set; }
        public Customer? Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime SaleDate { get; set; }
    }

    public class SalesItem
    {
        public int SalesItemId { get; set; }
        public Sale? Sale { get; set; }
        public int SaleId { get; set; }
        public Book? Book { get; set; }
        public int BookId { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal UnitPrice { get; set; }

    }
}
