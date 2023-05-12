using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Shared
{
    public class Genre
    {
        public int GenreId { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
