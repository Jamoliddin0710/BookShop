using Contracts;
using Entities.DTO.Book;
using MyShop.Services.AdminService.Contracts;

namespace MyShop.Services.AdminService
{
    public class PublisherService : IPublisherService
    {
        private readonly IRepositoryManager repositoryManager;

        public PublisherService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public Task AddPublisher(CreateBookDTO bookDTO)
        {
            throw new NotImplementedException();
        }

        public Task DeletePublisher(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<CreateBookDTO>> GetAllPublishers(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<CreateBookDTO> GetPublisherById(int bookId, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePublisher(int bookId, UpdateBookDTO bookDTO)
        {
            throw new NotImplementedException();
        }
    }
}
