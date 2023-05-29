using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract;
public interface IAuthorRepository
{
    void AddAuthor(Author author);
    void UpdateAuthor(Author author);
    void DeleteAll(IEnumerable<Author> authors);
    void DeleteAuhtor(Author author);
    Task<Author> GetAuhthorById(int authorId, bool trackChanges);
    IQueryable<Author> GetAllAuthor(bool trackChanges);
}

