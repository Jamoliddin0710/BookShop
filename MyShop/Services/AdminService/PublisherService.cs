using Contracts;
using Entities.DTO.Book;
using Entities.DTO.Publisher;
using Entities.DTO.Seller;
using Entities.Exceptions;
using Entities.Models;
using Entities.ModelView;
using Mapster;
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

        public async Task<PublisherDTO> AddPublisher(CreatePublisherDTO publisherDTO)
        {
            var publisher = publisherDTO.Adapt<Publisher>();
            
            repositoryManager.Publisher.AddPublisher(publisher);
            await repositoryManager.SaveAsync();
            return publisher.Adapt<PublisherDTO>();
        }

        public async Task DeletePublisher(int publisherId, bool trackChanges)
        {
            var publisher = await repositoryManager.Publisher.GetPublisherById(publisherId, trackChanges);
            
            if (publisher is null)
                throw new EntityNotFoundException<Publisher>();
            repositoryManager.Publisher.DeletePublisher(publisher);
            await repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<PublisherDTO>> GetAllPublishers(bool trackChanges)
        {
            var publishers = repositoryManager.Publisher.GetAllPublisher(trackChanges);
            
            if (publishers is null)
                return new List<PublisherDTO>();
            return publishers.Adapt<List<PublisherDTO>>();
        }

        public async Task<PublisherDTO> GetPublisherById(int publisherId, bool trackChanges)
        {
            var publisher = await repositoryManager.Publisher.GetPublisherById(publisherId, trackChanges);
            
            if (publisher is null)
                throw new EntityNotFoundException<Publisher>();
            return publisher.Adapt<PublisherDTO>();
        }

        public async Task UpdatePublisher(int publisherId , UpdatePublisherDTO updatePublisher)
        {
            var publisher = await repositoryManager.Publisher.GetPublisherById(publisherId, false);
            
            if (publisher is null)
                throw new EntityNotFoundException<Publisher>();
            var config = new TypeAdapterConfig();
            config.ForType<UpdatePublisherDTO, Publisher>()
                .IgnoreNullValues(true)
                .BeforeMapping((src, dest) =>
                {
                    dest.Id = publisher.Id;
                });

            var publisherupdate = updatePublisher.Adapt(publisher, config);
            repositoryManager.Publisher.UpdatePublisher(publisherupdate);
            await repositoryManager.SaveAsync();
        }
    }
}
