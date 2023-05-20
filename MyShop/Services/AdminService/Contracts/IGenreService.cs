using Entities.DTO.Genre;
using Entities.Models;
using Entities.ModelView;

namespace MyShop.Services.AdminService.Contracts
{
    public interface IGenreService
    {
        Task<GenreDTO> CreateGenre(CreateGenreDTO createGenreDTO);
        Task UpdateGenre(int genreId, UpdateGenreDTO updateGenreDTO);
        Task DeleteGenre(int id);
        Task<IEnumerable<GenreDTO>> GetAllGenre(bool trackChanges);
        Task<GenreDTO> GetGenreById(int genreId, bool trackChanges);
    }
}
