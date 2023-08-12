using Entities.DTO.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.AdminService;
using MyShop.Services.AdminService.Contracts;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IAdminServiceManager adminServiceManager;

        public FilesController(IAdminServiceManager adminServiceManager)
        {
            this.adminServiceManager = adminServiceManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddImage([FromForm] int bookId, [FromForm] CreateImageDTO createImage)
        {
            var images = await adminServiceManager.BookImage.AddImage(bookId, createImage, false);
            return Ok(images);
        }

        [HttpGet("{imageId:int}", Name = "Get-image")]
        public async Task<IActionResult> GetImageById(int imageId)
          => Ok(await adminServiceManager.BookImage.GetImageById(imageId, true));

        [HttpGet(Name = "GetAll-Images")]
        public async Task<IActionResult> GetAllImages()
          => Ok(await adminServiceManager.BookImage.GetAllImages(true));

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            await adminServiceManager.BookImage.DeleteImage(imageId);
            return NoContent();
        }

    }
}
