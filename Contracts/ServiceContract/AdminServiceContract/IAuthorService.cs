using Entities.DTO.Author;
using Entities.ModelView;

namespace MyShop.Services.AdminService.Contracts
{
    public interface IAuthorService
    {
        Task<AuthorDTO> CreateAuthor(CreateAuthorDTO authorDTO);
        Task UpdateAuthor(int authorId, UpdateAuthorDTO updateAuthor);
        Task DeleteAuthor(int authorId);
        Task DeleteAll();
        Task<AuthorDTO> GetAuthor(int authorId, bool trackChanges);
        Task<List<AuthorDTO>> GetAll(bool trackChanges);
    }
}
