using Entities.DTO.Publisher;
using Entities.Exceptions;
using Entities.ModelView;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.BuyerService.Contracts;
using Repository;

namespace MyShop.Controllers.AdminController
{
    [Route("api/[controller]")]
    //[Authorize(Roles = "Admin")]
    [ApiController]
    public class AdminPublisherController : ControllerBase
    {
        private readonly IBuyerServiceManager buyerServiceManager;

        public AdminPublisherController(IBuyerServiceManager buyerServiceManager)
        {
            this.buyerServiceManager = buyerServiceManager;
        }

        [HttpPost("create-publisher")]
        public async Task<IActionResult> CreatePublisher(CreatePublisherDTO createPublisher)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<CreatePublisherDTO>();
            await buyerServiceManager.Publisher.AddPublisher(createPublisher);
            return NoContent();// hamma create da object qaytarilishi kerak shun to'g'irlash kerak
        }

        [HttpPost("update-publisher")]
        public async Task<IActionResult> UpdatePublisher(int publisherId, UpdatePublisherDTO publisherDTO)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<UpdatePublisherDTO>();
            await buyerServiceManager.Publisher.UpdatePublisher(publisherId);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletaPublisher(int publisherId)
        {
            await buyerServiceManager.Publisher.DeletePublisher(publisherId, true);
            return NoContent();
        }

        [HttpGet]
        // filtr bilan yozish kerak
        public async Task<IActionResult> GetAllPublisher()
            => Ok(await buyerServiceManager.Publisher.GetAllPublishers(true));

        [HttpGet("get-publisher")]
        public async Task<IActionResult> GetPublisherById(int publisherId)
            => Ok(await buyerServiceManager.Publisher.GetPublisherById(publisherId, true));




    }
}
