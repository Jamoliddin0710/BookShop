using BookShopAdminFront.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopAdminFront.Models.DTO.Book
{
    public class UpdateBookDTO
    {
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public Decimal? Price { get; set; }
        public string? ISBN { get; set; }
        public ECover? Cover { get; set; }
        public Guid? genreId { get; set; }
        public EInscription? Inscription { get; set; }
        public ELanguage? Language { get; set; }
        public int? PagesCount { get; set; }
        public int? Count { get; set; }
    }
}
