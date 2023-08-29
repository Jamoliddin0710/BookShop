using Entities.DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyShop.Services.BuyerService.Contracts;

namespace MyShop.Controllers.AdminController
{
    //[Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public partial class Admin_AccountController : ControllerBase
    {
        private readonly IBuyerServiceManager buyerServiceManager;
        public IOptions<AppSettings> options;
        public Admin_AccountController(IBuyerServiceManager buyerServiceManager, IOptions<AppSettings> appSettings)
        {
            this.buyerServiceManager = buyerServiceManager;
            this.options = appSettings;
        }

        [HttpPost("sign-in")]
       // [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromQuery] UserCredentials userCredentials)
        {
            if (!ModelState.IsValid)
                return BadRequest($"{typeof(UserCredentials)} objects is null");

            var key = System.Text.Encoding.UTF8.GetBytes(options.Value.SecretKey);

            var authinfo = await buyerServiceManager.Buyer.SignInAsync(key, userCredentials, true);

            return Ok(authinfo);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var buyerDTO = await buyerServiceManager.Buyer.GetBuyerAsync(User, trackChanges: false);
            return Ok(buyerDTO);
        }
    }
}
