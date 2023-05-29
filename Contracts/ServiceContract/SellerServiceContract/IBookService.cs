using Entities.DTO.Book;
using Entities.ModelView;

namespace MyShop.Services.SellerService.Contracts
{
    public interface IBookService
    {
        Task<BookDTO> AddBook(CreateBookDTO bookDTO);
        Task DeleteBook(int bookId);
        Task UpdateBook(int bookId, UpdateBookDTO bookDTO);
        Task<BookDTO> GetBookById(int bookId, bool trackChanges);
        Task<List<BookDTO>> GetAllBooks(bool trackChanges);
    }
}
