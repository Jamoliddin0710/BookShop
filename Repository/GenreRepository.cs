using Contracts.RepositoryContract;
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
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(RepositoryContext context) : base(context)
        {
        }

        public void AddGenre(Genre genre) => Create(genre);

        public void DeleteGenre(Genre genre) => Delete(genre);

        public async Task<IQueryable<Genre>> GetAll(bool trackChanges)
            => FindAll(trackChanges)
            .Include(genre => genre.Books)
            .OrderBy(genre => genre.Name);

        public async Task<Genre> GetGenreById(int genreId, bool trackChanges)
            => await FindByCondition(genre => genre.Id == genreId, trackChanges).SingleOrDefaultAsync();
        public void UpdateGenre(Genre genre) => Update(genre);
    }
}
