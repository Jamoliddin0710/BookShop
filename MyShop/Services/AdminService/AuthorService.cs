using Contracts.RepositoryContract;
using Entities.DTO.Author;
using Entities.DTO.Genre;
using Entities.Exceptions;
using Entities.Models;
using Entities.ModelView;
using Mapster;
using MyShop.Services.AdminService.Contracts;
using Repository;

namespace MyShop.Services.AdminService
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepositoryManager repositoryManager;

        public AuthorService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<AuthorDTO> CreateAuthor(CreateAuthorDTO authorDTO)
        {
            var author = authorDTO.Adapt<Author>();

            repositoryManager.Author.AddAuthor(author);
            await repositoryManager.SaveAsync();
            return author.Adapt<AuthorDTO>();
        }

        public Task DeleteAll()
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAuthor(int authorId)
        {
            var author = await repositoryManager.Author.GetAuhthorById(authorId, false);

            if (author is null)
                throw new EntityNotFoundException<Author>();
            repositoryManager.Author.DeleteAuhtor(author);
            await repositoryManager.SaveAsync();
        }

        public async Task<List<AuthorDTO>> GetAll(bool trackChanges)
        {
            var authors =  repositoryManager.Author.GetAllAuthor(trackChanges);
            if (authors is null)
                return new List<AuthorDTO>();

            return authors.Adapt<List<AuthorDTO>>();
        }

        public async Task<AuthorDTO> GetAuthor(int authorId, bool trackChanges)
        {
            var author = await repositoryManager.Author.GetAuhthorById(authorId, trackChanges);

            if (author is null)
                throw new EntityNotFoundException<Author>();
            return author.Adapt<AuthorDTO>();
        }

        public async Task UpdateAuthor(int authorId, UpdateAuthorDTO updateAuthor)
        {
            var author = await repositoryManager.Author.GetAuhthorById(authorId, false);
            if (author is null)
                throw new EntityNotFoundException<Author>();

            var config = new TypeAdapterConfig();
            config.ForType<UpdateAuthorDTO, Author>()
                  .IgnoreNullValues(true)
                  .BeforeMapping((src, dest) =>
                  {
                      dest.Id = author.Id;
                  });

            var genreUpdate = updateAuthor.Adapt(author, config);
            repositoryManager.Author.UpdateAuthor(genreUpdate);
            await repositoryManager.SaveAsync();
        }
    }
}
