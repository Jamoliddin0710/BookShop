using Contracts.RepositoryContract;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using MyShop.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateOrder(Order order) => Create(order);

        public void DeleteOrderAll(IEnumerable<Order> orders) => DeleteRange(orders);

        public void DeleteOrder(Order order) => Delete(order);

        public IQueryable<Order> GetBuyerOrders(bool trackChanges)
        => FindAll(trackChanges).Include(order => order.OrderBooks);

        public void UpdateOrder(Order order) => UpdateOrder(order);

        public async Task<Order> GetOrderById(int orderId, bool trackChanges)
            => await FindByCondition(order => order.Id == orderId, trackChanges).Include(order=>order.OrderBooks).SingleOrDefaultAsync();
    }
}
