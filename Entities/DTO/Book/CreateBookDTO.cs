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
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Summary { get; set; }
        [Required]
        public Decimal? Price { get; set; }
        [Required]
        public string? ISBN { get; set; }
        [Required]
        public ECover Cover { get; set; }
        [Required]
        public int authorId { get; set; }
        [Required]
        public Guid sellerId { get; set; }
        [Required]
        public EInscription Inscription { get; set; }
        [Required]
        public int publisherId { get; set; }
        [Required]
        public ELanguage Language { get; set; }
        [Required]
        public int PagesCount { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public int genreId { get; set; }
        
    }
}
