using Entities.DTO.Order;
using Entities.ModelView;
using MyShop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContract.BuyerServiceContract
{
    public interface IOrderService
    {
        public Task<OrderDTO> CreateOrder(ClaimsPrincipal claims, CreateOrderDTO createOrderDTO);
        public Task<IEnumerable<OrderDTO>> GetOrders(PaginationParams paginationParams, ClaimsPrincipal claims);
        public Task DeleteOrder(int orderId);
        public Task DeleteAllOrder();

    }
}
