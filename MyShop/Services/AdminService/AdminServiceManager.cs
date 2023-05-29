using Entities;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BuyerService;
using MyShop.Services.BuyerService.Contracts;
using MyShop.Services.SellerService.Contracts;
using MyShop.Services.SellerService;
using Contracts.RepositoryContract;

namespace MyShop.Services.AdminService
{
    public class AdminServiceManager : IAdminServiceManager
    {
        private readonly Lazy<IBuyerService> buyerService;
        private readonly Lazy<IAuthorService> authorService;
        private readonly Lazy<IGenreService> genreService;
        private readonly Lazy<IPublisherService> publisherService;
        private readonly Lazy<ISellerService> sellerService;
        public AdminServiceManager(IRepositoryManager repositoryManager)
        {
            this.authorService = new Lazy<IAuthorService>(() => new AuthorService(repositoryManager));
            this.genreService = new Lazy<IGenreService>(() => new GenreService(repositoryManager));
            this.publisherService = new Lazy<IPublisherService>(() => new PublisherService(repositoryManager));
            this.buyerService = new Lazy<IBuyerService>(() => new MyShop.Services.BuyerService.BuyerService(repositoryManager));
            this.sellerService = new Lazy<ISellerService>(()=> new MyShop.Services.SellerService.SellerService(repositoryManager));
        }
        public IPublisherService Publisher => publisherService.Value;

        public IAuthorService Author => authorService.Value;

        public IGenreService Genre => genreService.Value;

        public IBuyerService Buyer => buyerService.Value;

        public ISellerService Seller => sellerService.Value;
    }
}
