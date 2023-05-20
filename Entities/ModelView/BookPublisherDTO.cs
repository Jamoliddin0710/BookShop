using Entities.Models;
using Newtonsoft.Json;
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
        [JsonIgnore]
        public BookDTO? Book { get; set; }
        public int publisherId { get; set; }
        [JsonIgnore]
        public PublisherDTO? Publisher { get; set; }
    }
}
