using Entities.DTO.Book;
using Entities.Exceptions;
using Entities.Models;
using Mapster;
using MyShop.Services.BookService.Contracts;
using Repository;

namespace MyShop.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly RepositoryManager repositoryManager;
        public BookService(RepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task AddBook(CreateBookDTO bookDTO)
        {
            var book = bookDTO.Adapt<Book>();
            book.CreatedDate = DateTime.UtcNow;
            repositoryManager.Book.AddBook(book);
            await repositoryManager.SaveAsync();
        }

        public async Task DeleteBook(int bookId)
        {
            var book = await repositoryManager.Book.GetBookById(bookId, false);
            repositoryManager.Book.DeleteBook(book);
            await repositoryManager.SaveAsync();
        }

        public async Task<ICollection<CreateBookDTO>> GetAllBooks(bool trackChanges)
        {
            var books =  repositoryManager.Book.GetAllBook(trackChanges);
            
            if(books is null)
                return new List<CreateBookDTO>();
            return books.Adapt<ICollection<CreateBookDTO>>();
        }

        public async Task<CreateBookDTO> GetBookById(int bookId, bool trackChanges)
        {
            var book = await repositoryManager.Book.GetBookById(bookId, trackChanges);
            if (book is null)
                throw new EntityNotFoundException<Book>();
            
            return book.Adapt<CreateBookDTO>(); 
        }

        public async Task UpdateBook(int bookId, UpdateBookDTO bookDTO)
        {
            var book = await repositoryManager.Book.GetBookById(bookId, false);
            book.Name = bookDTO.Name;
            book.Description = bookDTO.Description;
            book.Cover = bookDTO.Cover;
            // book.authorId = bookDTO.authorId;
            book.Price = bookDTO.Price;
            book.Count = bookDTO.Count;
            book.genreId = bookDTO.genreId;
            repositoryManager.Book.UpdateBook(book);
            await repositoryManager.SaveAsync();
        }

    }
}
