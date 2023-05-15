using Entities.DTO.Seller;
using Entities.DTO.User;
using Entities.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MyShop.Services.SellerService.Contracts;

namespace MyShop.Controllers.SellerController
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Seller")]
    [ApiController]
    public class SellerAccountController : ControllerBase
    {
        private readonly ISellerServiceManager serviceManager;
        IOptions<AppSettings> options { get; }
        public SellerAccountController(ISellerServiceManager serviceManager, IOptions<AppSettings> options)
        {
            this.serviceManager = serviceManager;
            this.options = options;
        }

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp(CreateSellerDTO sellerDTO)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<CreateSellerDTO>();
            var key = System.Text.Encoding.UTF8.GetBytes(options.Value.SecretKey);
            var userAuth = await serviceManager.Seller.SignUp(key, sellerDTO);
            return Ok(userAuth);
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn(UserCredentials userCredentials, CancellationToken token)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<UserCredentials>();
            var key = System.Text.Encoding.UTF8.GetBytes(options.Value.SecretKey);
            var userAuth = await serviceManager.Seller.SignInAsync(key, userCredentials, true);
            return Ok(userAuth);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var seller = await serviceManager.Seller.GetSellerAsync(User, trackChanges: true);
            return Ok(seller);
        }

        [HttpPost("edit-profile")]
        public async Task<IActionResult> EditProfile(UpdateSellerDTO sellerDTO)
        {
            serviceManager.Seller.UpdateSellerasync(User, sellerDTO, true);
            return Ok();
        }
    }
}
