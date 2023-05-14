using Entities.DTO.Book;

namespace MyShop.Services.BookService.Contracts
{
    public interface IBookService
    {
        Task AddBook(CreateBookDTO bookDTO);
        Task DeleteBook(int bookId);
        Task UpdateBook(int bookId, UpdateBookDTO bookDTO);
        Task<CreateBookDTO> GetBookById(int bookId, bool trackChanges);
        Task<ICollection<CreateBookDTO>> GetAllBooks(bool trackChanges);
    }
}
