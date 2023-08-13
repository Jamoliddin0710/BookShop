using BookShopAdminFront.Filters;
using BookShopAdminFront.Models;

namespace BookShopAdminFront.DTO.Book
{
    public class BookFilterDTO : PaginationParams
    {
        public Decimal? FromPrice { get; set; }
        public Decimal? ToPrice { get; set; }
        public ECover? Cover { get; set; }
        public EBookSotringStatus? SortingStatus { get; set; }
        public int? genreId { get; set; }
        public EInscription? Inscription { get; set; }
        public int? publisherId { get; set; }
        public ELanguage? Language { get; set; }
    }
}