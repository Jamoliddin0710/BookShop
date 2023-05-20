using Entities.DTO.Book;
using Entities.DTO.Publisher;
using Entities.Models;
using Entities.ModelView;

namespace MyShop.Services.AdminService.Contracts
{
    public interface IPublisherService
    {
        Task<PublisherDTO> AddPublisher(CreatePublisherDTO publisherDTO);
        Task DeletePublisher(int publisherId , bool trackChanges);
        Task UpdatePublisher(int publisherId , UpdatePublisherDTO updatePublisher);
        Task<PublisherDTO> GetPublisherById(int publisherId, bool trackChanges);
        Task<IEnumerable<PublisherDTO>> GetAllPublishers(bool trackChanges);
    }
}
