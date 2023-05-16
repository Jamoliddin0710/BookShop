using Entities.DTO.Book;
using Entities.ModelView;

namespace MyShop.Services.BookService.Contracts
{
    public interface IBookService
    {
        Task AddBook(CreateBookDTO bookDTO);
        Task DeleteBook(int bookId);
        Task UpdateBook(int bookId, UpdateBookDTO bookDTO);
        Task<BookDTO> GetBookById(int bookId, bool trackChanges);
        Task<ICollection<BookDTO>> GetAllBooks(bool trackChanges);
    }
}
