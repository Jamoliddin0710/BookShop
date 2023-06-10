using Entities.DTO.Image;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.AdminService.Contracts;

namespace MyShop.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IAdminServiceManager adminService;

        public FilesController(IAdminServiceManager adminService)
        {
            this.adminService = adminService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(int bookId, [FromForm] CreateImageDTO imageDTO)
        {
            var image = await adminService.Image.AddImage(bookId, imageDTO, false);
            return Ok(image);
        }

        [HttpGet("{imageId:int}", Name = "get-image")]
        public async Task<IActionResult> GetImageById(int imageId)
        {
            return Ok(await adminService.Image.GetImageById(imageId, false));
        }

        [HttpGet(Name = "Get-All")]
        public async Task<IActionResult> GetAllImages()
        {
            return Ok(await adminService.Image.GetAllImages(false));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            await adminService.Image.DeleteImage(imageId);
            return NoContent();
        }

    }
}
