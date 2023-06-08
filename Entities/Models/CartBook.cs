using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CartBook
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book? Book { get; set; }
        public int CartId { get; set; }
        [ForeignKey(nameof(CartId))]
        public Cart? Cart { get; set; }
        public uint Count { get; set; }
    }
}
