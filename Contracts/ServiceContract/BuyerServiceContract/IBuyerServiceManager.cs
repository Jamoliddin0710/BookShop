
using Contracts.ServiceContract.BuyerServiceContract;

namespace MyShop.Services.BuyerService.Contracts
{
    public interface IBuyerServiceManager
    {
        IBuyerService Buyer { get; }
        IBookService Book { get; }
        IOrderService Order { get; }
    }
}
