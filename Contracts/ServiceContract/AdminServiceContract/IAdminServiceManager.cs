using Contracts.ServiceContract.AdminServiceContract;
using MyShop.Services.BuyerService.Contracts;

namespace MyShop.Services.AdminService.Contracts
{
    public interface IAdminServiceManager
    {
        public IPublisherService Publisher {  get; }
        public IAuthorService Author { get; }
        public IGenreService Genre { get; }
        public IBuyerService Buyer { get; } 
        public IBookService Book { get; }
        public IBookImageService BookImage { get; }
    }
}
