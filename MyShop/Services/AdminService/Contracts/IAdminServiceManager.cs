using MyShop.Services.BuyerService.Contracts;

namespace MyShop.Services.AdminService.Contracts
{
    public interface IAdminServiceManager
    {
        public IPublisherService Publisher {  get; }
        public IAuthorService Author { get; }
        public IGenreService Genre { get; }
        public IBuyerService Buyer { get; }
    }
}
