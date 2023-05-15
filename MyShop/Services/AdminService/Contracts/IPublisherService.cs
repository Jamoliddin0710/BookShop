using Entities.DTO.Book;

namespace MyShop.Services.AdminService.Contracts
{
    public interface IPublisherService
    {
        Task AddPublisher( bookDTO);
        Task DeletePublisher(int bookId);
        Task UpdatePublisher(int bookId, UpdateBookDTO bookDTO);
        Task<CreateBookDTO> GetPublisherById(int bookId, bool trackChanges);
        Task<ICollection<CreateBookDTO>> GetAllPublishers(bool trackChanges);
    }
}
