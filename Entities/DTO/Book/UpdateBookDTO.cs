using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Book
{
    public class UpdateBookDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Decimal? Price { get; set; }
        public ECover Cover { get; set; }
        public Guid? authorId { get; set; }
        public EInscription Inscription { get; set; }
        public ELanguage Language { get; set; }
        public int? PagesCount { get; set; }
        public int? Count { get; set; }
        public int? genreId { get; set; }
    }
}
