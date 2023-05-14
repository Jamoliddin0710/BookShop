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
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public Decimal? Price { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public ECover Cover { get; set; }
        [Required]
        public Guid? authorId {  get; set; }
        [ForeignKey("authorId")]
        public Author? Author { get; set; }
        public EInscription Inscription { get; set; }
        public ICollection<BookPublisher> BookPublishers { get; set; }
        public ELanguage Language { get; set; }
        public ICollection<Image> Images { get; set; }
        [Required]
        public int? PagesCount { get; set; }
        [Required]
        public int? Count { get; set; }
        public int?  genreId { get; set; }
        [ForeignKey(nameof(genreId))]
        public Genre? Genre { get; set; }
    }
}
