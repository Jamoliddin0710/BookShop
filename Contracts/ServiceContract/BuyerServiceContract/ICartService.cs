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
    public class ICartService
    {
        public Task<> CreateCart(ClaimsPrincipal claims, CreateOrderDTO createOrderDTO);
        public Task<IEnumerable<>> GetCarts(PaginationParams paginationParams, ClaimsPrincipal claims);
        public Task DeleteCart(int orderId);
        public Task DeleteAllOrder();
    }
}
