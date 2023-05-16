using Contracts;
using Entities;
using MyShop.Services.SellerService.Contracts;

namespace MyShop.Services.SellerService
{
    public class SellerServiceManager : ISellerServiceManager
    {
        private readonly Lazy<ISellerService> service;

        public SellerServiceManager(IRepositoryManager repositoryManager)
        {
            this.service = new Lazy<ISellerService>(() => new SellerService(repositoryManager));
        }

        public ISellerService Seller => throw new NotImplementedException();

        public IBookRepository Book => throw new NotImplementedException();
    }
}
