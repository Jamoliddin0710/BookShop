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
    public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(RepositoryContext context) : base(context)
        {
        }

        public void AddAuthor(Author author) => Create(author);

        public void DeleteAll(IEnumerable<Author> authors) => DeleteAll(authors);

        public void DeleteAuhtor(Author author) => Delete(author);

        public IQueryable<Author> GetAllAuthor(bool tracking)
            => FindAll(tracking).Include(author => author.Books);

        public async Task<Author> GetAuhthorById(int authorId, bool trackChanges)
            => await FindByCondition(author => author.Id == authorId, trackChanges).SingleOrDefaultAsync();

        public void UpdateAuthor(Author author) => Update(author);
    }
}
