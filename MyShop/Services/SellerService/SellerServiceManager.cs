using Contracts;
using Entities;
using MyShop.Services.SellerService.Contracts;

namespace MyShop.Services.SellerService
{
    public class SellerServiceManager : ISellerServiceManager
    {
        private readonly Lazy<ISellerService> sellerService;
        private readonly Lazy<IBookService> bookService;

        public SellerServiceManager(IRepositoryManager repositoryManager)
        {
            this.sellerService = new Lazy<ISellerService>(() => new SellerService(repositoryManager));
            this.bookService = new Lazy<IBookService>(() => new BookService(repositoryManager)); 
        }


        public ISellerService Seller => sellerService.Value;

        public IBookService Book => bookService.Value;
    }
}
