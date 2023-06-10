using Contracts.RepositoryContract;
using Contracts.ServiceContract.BuyerServiceContract;
using Entities.DTO.Order;
using Entities.Exceptions;
using Entities.Models;
using Entities.ModelView;
using Mapster;
using MyShop.Filters;
using System.Security.Claims;

namespace MyShop.Services.BuyerService
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager repositoryManager;

        public OrderService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<OrderDTO> CreateOrder(ClaimsPrincipal claims, CreateOrderDTO createOrderDTO)
        {
            Guid buyerId;
            try
            {
                buyerId = Guid.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            catch (Exception ex)
            {
                throw new Exception($"User not registred Error message {ex.Message}");
            }

            var buyer = await repositoryManager.Buyer.GetBuyerAsync(buyerId, true);

            if (buyer is null)
                throw new EntityNotFoundException<Buyer>();

            var order = new Order()
            {
                CreatedAt = DateTime.UtcNow,
                OrderStatus = Entities.Models.Enums.EOrderStatus.Created
            };
            repositoryManager.Order.CreateOrder(order);
            await repositoryManager.SaveAsync();

           // var orderbooks = new List<OrderBook>();
           order.OrderBooks ??= new List<OrderBook>();
            foreach (var orderbook in createOrderDTO.OrderBooks)
            {
              /*  orderbooks.Add(new OrderBook()
                {
                    OrderId = order.Id,
                    BookId = orderbook.BookId,
                    Count = orderbook.Count,
                });
              */
                order.OrderBooks.Add(new OrderBook()
                {
                    OrderId = order.Id,
                    BookId = orderbook.BookId,
                    Count = orderbook.Count,
                });
            }

          //  order.OrderBooks = orderbooks;
            order.LastUpdatedAt = DateTime.UtcNow;
            repositoryManager.Order.UpdateOrder(order);
            await repositoryManager.SaveAsync();

            var orderview = order.Adapt<OrderDTO>();
            return orderview;
        }

        public async Task DeleteAllOrder()
        {
            var orders = repositoryManager.Order.GetBuyerOrders(true);
            repositoryManager.Order.DeleteOrderAll(orders);
            await repositoryManager.SaveAsync();
        }

        public async Task DeleteOrder(int orderId)
        {
            var order = await repositoryManager.Order.GetOrderById(orderId, false);
            repositoryManager.Order.DeleteOrder(order);
            await repositoryManager.SaveAsync();
        }

        public Task<IEnumerable<OrderDTO>> GetOrders(PaginationParams paginationParams, ClaimsPrincipal claims)
        {
            throw new Exception();
        }
    }
}
