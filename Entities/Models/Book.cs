using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Book
    {
        [Column("bookId")]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public Decimal Price { get; set; }
        public string? ISBN { get; set; }
        public DateTime CreatedDate { get; set; }
        public ECover Cover { get; set; }
        public EInscription Inscription { get; set; }
        public ELanguage Language { get; set; }
        public List<Image>? Images { get; set; }
        public int PagesCount { get; set; }
        public int publisherId { get; set; }
        [ForeignKey(nameof(publisherId))]
        public Publisher? Publisher { get; set; }
        public int? authorId { get; set; }
        [ForeignKey("authorId")]
        public Author? Author { get; set; }
        public int Count { get; set; }
        public int? genreId { get; set; }
        [ForeignKey(nameof(genreId))]
        public Genre? Genre { get; set; }
    }
}
