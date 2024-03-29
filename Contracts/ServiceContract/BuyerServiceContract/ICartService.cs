﻿using Entities.DTO.Order;
using Entities.Models;
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
    public interface ICartService
    {
        public Task<Cart> CreateCart(ClaimsPrincipal claims, CreateOrderDTO createOrderDTO);
        public Task<IEnumerable<Cart>> GetCarts(PaginationParams paginationParams, ClaimsPrincipal claims);
        public Task DeleteCart(int orderId);
        public Task DeleteAllOrder();
    }
}
