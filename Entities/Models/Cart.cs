using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Guid BuyerId { get; set; }
        [ForeignKey(nameof(BuyerId))]
        public Buyer? Buyer { get; set; }
        public List<CartBook>? CartBooks { get; set; }
    }
}
