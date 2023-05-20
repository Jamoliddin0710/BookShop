using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IBookRepository
    {
        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteAllBook();
        void DeleteBook(Book book);
        Task<Book> GetBookById(int bookId, bool trackChanges);
        IQueryable<Book> GetAllBook(bool trackChanges);
    }
}
