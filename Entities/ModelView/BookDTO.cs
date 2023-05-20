using Entities.Models.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Entities.ModelView
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public Decimal? Price { get; set; }
        public string ISBN { get; set; }
        public DateTime CreatedDate { get; set; }
        public ECover Cover { get; set; }
        public int? authorId { get; set; }
        [JsonIgnore]
        public AuthorDTO? Author { get; set; }
        public EInscription Inscription { get; set; }
        [JsonIgnore]
        public ICollection<BookPublisherDTO>? BookPublishers { get; set; }
        public ELanguage Language { get; set; }

        //  public ICollection<ImageDTO> Images { get; set; }
        public int PagesCount { get; set; }
        public int Count { get; set; }
       // public int? genreId { get; set; }
        public string? GenreName { get; set; }
    }
}
