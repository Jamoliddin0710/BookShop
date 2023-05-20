using Contracts;

namespace MyShop.Services.SellerService.Contracts
{
    public interface ISellerServiceManager
    {
        ISellerService Seller { get; }
        IBookService Book { get; }
    }
}
