using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;
public interface IAuthorRepository
{
    void AddBook(Author author);
    void UpdateBook(Author author);
    void DeleteAllBook();
    void DeleteBook(Author author);
    Task<Book> GetBookById(int bookId, bool trackChanges);
    IQueryable<Book> GetAllBook(bool tracking);
}

