using Contracts.RepositoryContract;
using Entities.DTO.Genre;
using Entities.DTO.Seller;
using Entities.Exceptions;
using Entities.Models;
using Entities.ModelView;
using Mapster;
using Microsoft.EntityFrameworkCore;
using MyShop.Services.AdminService.Contracts;
using Repository;
using System;

namespace MyShop.Services.AdminService
{
    public class GenreService : IGenreService
    {
        private readonly IRepositoryManager repositoryManager;

        public GenreService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenreDTO> CreateGenre(CreateGenreDTO createGenreDTO)
        {
            var genre = createGenreDTO.Adapt<Genre>();

            repositoryManager.Genre.AddGenre(genre);
            await repositoryManager.SaveAsync();

            return genre.Adapt<GenreDTO>();
        }

        public async Task DeleteGenre(int id)
        {
            var genre = await repositoryManager.Genre.GetGenreById(id, false);

            if (genre is null)
                throw new EntityNotFoundException<Genre>();

            repositoryManager.Genre.DeleteGenre(genre);
            await repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<GenreDTO>> GetAllGenre(bool trackChanges)
        {
            var genres = await repositoryManager.Genre.GetAll(trackChanges);
            if (genres is null)
                return new List<GenreDTO>();
            
           var dtomodel =  (await genres.ToListAsync()).Adapt<IEnumerable<GenreDTO>>();
            return dtomodel;
        }

        public async Task<GenreDTO> GetGenreById(int genreId, bool trackChanges)
        {
            var genre = await repositoryManager.Genre.GetGenreById(genreId, trackChanges);

            if (genre is null)
                throw new EntityNotFoundException<Genre>();

            return genre.Adapt<GenreDTO>();
        }

        public async Task UpdateGenre(int genreId, UpdateGenreDTO updateGenreDTO)
        {
            var genre = await repositoryManager.Genre.GetGenreById(genreId, true);

            if (genre is null)
                throw new EntityNotFoundException<Genre>();

            var config = new TypeAdapterConfig();

            config.ForType<UpdateGenreDTO, Genre>()
                  .IgnoreNullValues(true)
                  .BeforeMapping((src, dest) =>
                  {
                      dest.Id = genre.Id;
                      dest.Books = genre.Books;
                  });

            var genreUpdate = updateGenreDTO.Adapt(genre, config);

            repositoryManager.Genre.UpdateGenre(genreUpdate);
            await repositoryManager.SaveAsync();
        }
    }
}
