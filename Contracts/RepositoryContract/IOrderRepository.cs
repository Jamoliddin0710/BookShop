using Entities.Models;
using MyShop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
        void DeleteOrderAll(IEnumerable<Order> orders);
        void DeleteOrder(Order order);
        void UpdateOrder(Order order);
        Task<Order> GetOrderById(int orderId , bool trackChanges);
        IQueryable<Order> GetBuyerOrders(bool trackChanges);
    }
}
