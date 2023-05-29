using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract
{
    public interface IGenreRepository
    {
        void AddGenre(Genre genre);
        void UpdateGenre(Genre genre);
        void DeleteGenre(Genre genre);
        //   void DeleteAll(IQueryable<Genre> genres);
        Task<Genre> GetGenreById(int genreId, bool trackChanges);
        Task<IQueryable<Genre>> GetAll(bool trackChanges);
    }
}
