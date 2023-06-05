using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BookShopFront.Models.ModelView
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public decimal? Price { get; set; }
        public string ISBN { get; set; }
        public DateTime CreatedDate { get; set; }
        public ECover Cover { get; set; }
        public string? AuthorFullName { get; set; }
        public EInscription Inscription { get; set; }
        public string? PublisherName { get; set; }
        public ELanguage Language { get; set; }
        //  public ICollection<ImageDTO> Images { get; set; }
        public int PagesCount { get; set; }
        public int Count { get; set; }
        public string? GenreName { get; set; }
    }
}
