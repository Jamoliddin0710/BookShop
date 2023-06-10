using Contracts.RepositoryContract;
using Contracts.ServiceContract.BuyerServiceContract;
using MyShop.Services.BuyerService.Contracts;

namespace MyShop.Services.BuyerService
{
    public class BuyerServiceManager : IBuyerServiceManager
    {
        private readonly Lazy<IBuyerService> buyerService;
        private readonly Lazy<IBookService> bookService;
        private readonly Lazy<IOrderService> orderService;
        public BuyerServiceManager(IRepositoryManager repository)
        {
            this.buyerService = new Lazy<IBuyerService>(() => new BuyerService(repository));
            this.bookService = new Lazy<IBookService>(() => new BookService(repository));
            this.orderService = new Lazy<IOrderService>(() => new OrderService(repository));
        }
        public IBuyerService Buyer => buyerService.Value;
        public IBookService Book => bookService.Value;
        public IOrderService Order => orderService.Value;
    }
}
