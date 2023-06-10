using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelView
{
    public class OrderBookDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public BookDTO? Book { get; set; }
        public int Count { get; set; }
    }
}
