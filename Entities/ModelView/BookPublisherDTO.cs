using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelView
{
    public class BookPublisherDTO
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public BookDTO? Book { get; set; }
        public int publisherId { get; set; }
        public PublisherDTO? Publisher { get; set; }
    }
}
