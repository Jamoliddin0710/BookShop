
using BookShopFront.Filters;
using BookShopFront.Models;

namespace BookShopFront.DTO.Book
{
    public class BookFilterDTO : PaginationParams
    {
        public Decimal? FromPrice { get; set; }
        public Decimal? ToPrice { get; set; }
        public ECover? Cover { get; set; }
        public EBookSotringStatus? SortingStatus { get; set; }
        public int? authorId { get; set; }
        public EInscription? Inscription { get; set; }
        public int? publisherId { get; set; }
        public ELanguage? Language { get; set; }
        public int? genreId { get; set; }
    }
}