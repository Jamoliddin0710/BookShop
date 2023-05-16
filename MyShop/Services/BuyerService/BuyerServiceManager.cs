using Contracts;
using Entities.DTO.User;
using Microsoft.Extensions.Options;
using MyShop.Services.AdminService;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BuyerService.Contracts;
using Repository;

namespace MyShop.Services.BuyerService
{
    public class BuyerServiceManager : IBuyerServiceManager
    {
        private readonly Lazy<IBuyerService> buyerService;
        private readonly Lazy<IPublisherService> publisherService;
        public BuyerServiceManager(IRepositoryManager repository)
        {
            this.buyerService = new Lazy<IBuyerService>(() => new BuyerService(repository));
            this.publisherService = new Lazy<IPublisherService>(() => new PublisherService(repository));
        }

        public IBuyerService Buyer => buyerService.Value;

        public IPublisherService Publisher => publisherService.Value;
    }
}
