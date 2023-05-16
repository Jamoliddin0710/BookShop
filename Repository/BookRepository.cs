using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context) { }
        public void AddBook(Book book) => Create(book);

        public void DeleteAllBook() => DeleteAll();

        public void DeleteBook(Book book) => Delete(book);

        public IQueryable<Book> GetAllBook(bool tracking) =>  
            FindAll(tracking).Include(book=>book.Author).Include(book=>book.BookPublishers)
            .Include(book=>book.Images).OrderBy(book=>book.Title);

        public async Task<Book> GetBookById(int bookId, bool trackChanges) =>
            await FindByCondition(book => book.Id == bookId, trackChanges)
            .SingleOrDefaultAsync();

        public void UpdateBook(Book book) => Update(book);
    }
}
