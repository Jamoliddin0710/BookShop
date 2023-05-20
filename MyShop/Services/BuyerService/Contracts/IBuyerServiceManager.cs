using MyShop.Services.AdminService.Contracts;

namespace MyShop.Services.BuyerService.Contracts
{
    public interface IBuyerServiceManager
    {
        IBuyerService Buyer { get; }
        IPublisherService Publisher { get; }
        IAuthorService Author { get; }
        IGenreService Genre { get; }
    }
}
