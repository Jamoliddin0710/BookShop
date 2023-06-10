using Entities.DTO.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.BuyerService.Contracts;
using Repository;

namespace MyShop.Controllers.BuyerController
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBuyerServiceManager buyerServiceManager;

        public OrderController(IBuyerServiceManager buyerServiceManager)
        {
            this.buyerServiceManager = buyerServiceManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderDTO createOrder)
        => Ok(await buyerServiceManager.Order.CreateOrder(User, createOrder));
    }
}
