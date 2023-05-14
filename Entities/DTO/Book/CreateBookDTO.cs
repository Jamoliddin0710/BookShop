using Entities.Models.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Book
{
    public class CreateBookDTO
    {
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Decimal Price { get; set; }
        public ECover Cover { get; set; }
        [Required]
        public Guid authorId { get; set; }
        public EInscription Inscription { get; set; }
        public ELanguage Language { get; set; }
        [Required]
        public int PagesCount { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int genreId { get; set; }
    }
}
