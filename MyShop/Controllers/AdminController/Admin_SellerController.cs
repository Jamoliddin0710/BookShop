using Entities.DTO.Seller;
using Entities.ModelView;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.AdminService.Contracts;
using System.Runtime.CompilerServices;

namespace MyShop.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_SellerController : ControllerBase
    {
        private readonly IAdminServiceManager adminServiceManager;

        public Admin_SellerController(IAdminServiceManager adminServiceManager)
        {
            this.adminServiceManager = adminServiceManager;
        }

        [HttpGet("api/Admin_Seller")]
        public async Task<IActionResult> GetAllSellers()
        {
            var sellers = await adminServiceManager.Seller.GetAllSeller(true);
            return Ok(sellers);
        }

        [HttpGet("{sellerId:Guid}", Name = "Get-Seller")]
        public async Task<IActionResult> GetSellerById(Guid sellerid)
          => Ok(await adminServiceManager.Seller.GetSellerById(sellerid, true));

        [HttpGet("api/Admin_Seller/{phone}", Name = "Get-ByPhone")]
        public async Task<IActionResult> GetSellerByPhone(string phone)
         => Ok(await adminServiceManager.Seller.GetSellerByPhone(phone, true));

        [HttpPut(Name = "update-seller")]
        public async Task<IActionResult> UpdateSeller(Guid sellerid, UpdateSellerDTO updateSeller)
        {
            await adminServiceManager.Seller.UpdateSeller(sellerid, updateSeller);
            return NoContent();
        }

        [HttpDelete("delete-seller")]
        public async Task<IActionResult> DeleteSeller(Guid sellerid)
        {
            await adminServiceManager.Seller.DeleteSeller(sellerid);
            return NoContent();
        }
    }
}
