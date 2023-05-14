using Contracts;
using Entities.DTO.User;
using Microsoft.Extensions.Options;
using MyShop.Services.BuyerService.Contracts;
using Repository;

namespace MyShop.Services.BuyerService
{
    public class BuyerServiceManager : IBuyerServiceManager
    {
        private readonly Lazy<IBuyerService> buyerService;
        private readonly IOptions<AppSettings> options;
        public BuyerServiceManager(IRepositoryManager repository)
        {
            buyerService = new Lazy<IBuyerService>(() => new BuyerService(repository));

           
        }

        public IBuyerService Buyer => buyerService.Value;
    }
}
