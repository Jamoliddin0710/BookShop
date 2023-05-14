using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class BookPublisher
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        [ForeignKey(nameof(bookId))]
        public Book? Book { get; set; }
        public int publisherId { get; set; }
        [ForeignKey(nameof(publisherId))]
        public Publisher? Publisher { get; set; }
    }
}
