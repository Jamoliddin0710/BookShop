using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelView
{
    public class CartBookDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public BookDTO? Book { get; set; }
        public int CartId { get; set; }
        [ForeignKey(nameof(CartId))]
        public CartDTO? Cart { get; set; }
        public uint Count { get; set; }
    }
}
