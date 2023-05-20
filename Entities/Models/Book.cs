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
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Summary { get; set; }
        [Required]
        public Decimal? Price { get; set; }
        [Required]
        public string? ISBN { get; set; }
        public DateTime CreatedDate { get; set; }
        public ECover Cover { get; set; }
        [Required]
        public int authorId {  get; set; }
        [ForeignKey("authorId")]
        public Author? Author { get; set; }
        public EInscription Inscription { get; set; }
        public List<BookPublisher> BookPublishers { get; set; }
        public ELanguage Language { get; set; }
        public List<Image> Images { get; set; }
        [Required]
        public int PagesCount { get; set; }
        [Required]
        public int Count { get; set; }
        public int?  genreId { get; set; }
        [ForeignKey(nameof(genreId))]
        public Genre? Genre { get; set; }
    }
}
