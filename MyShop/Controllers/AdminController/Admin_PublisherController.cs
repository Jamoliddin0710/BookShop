using Entities.DTO.Publisher;
using Entities.Exceptions;
using Entities.ModelView;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BuyerService.Contracts;
using Repository;

namespace MyShop.Controllers.AdminController
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    [ApiController]
    public class Admin_PublisherController : ControllerBase
    {
        private readonly IAdminServiceManager adminServiceManager;

        public Admin_PublisherController(IAdminServiceManager adminServiceManager)
        {
            this.adminServiceManager = adminServiceManager;
        }

        [HttpPost("create-publisher")]
        public async Task<IActionResult> CreatePublisher(CreateGenreDTO createPublisher)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<CreateGenreDTO>();
            var publisher = await adminServiceManager.Publisher.AddPublisher(createPublisher);
            return Ok(publisher);
        }

        [HttpPut("update-publisher")]
        public async Task<IActionResult> UpdatePublisher(int publisherId, UpdateGenreDTO GenreDTO)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<UpdateGenreDTO>();
            await adminServiceManager.Publisher.UpdatePublisher(publisherId, GenreDTO);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletaPublisher(int publisherId)
        {
            await adminServiceManager.Publisher.DeletePublisher(publisherId, true);
            return NoContent();
        }

        [HttpGet]
        // filtr bilan yozish kerak
        public async Task<IActionResult> GetAllPublisher()
            => Ok(await adminServiceManager.Publisher.GetAllPublishers(true));

        [HttpGet("get-publisher")]
        public async Task<IActionResult> GetPublisherById(int publisherId)
            => Ok(await adminServiceManager.Publisher.GetPublisherById(publisherId, true));
    }
}
