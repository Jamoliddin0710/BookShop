
using Entities.DTO.Author;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.AdminService.Contracts;
using MyShop.Services.BuyerService.Contracts;

namespace MyShop.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_AuthorController : ControllerBase
    {
        private readonly IAdminServiceManager adminServiceManager;

        public Admin_AuthorController(IAdminServiceManager adminServiceManager)
        {
            this.adminServiceManager = adminServiceManager;
        }

        [HttpPost(Name = "add-author")]
        public async Task<IActionResult> AddAuthor(CreateAuthorDTO createAuthor)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<Author>();
            var author = await adminServiceManager.Author.CreateAuthor(createAuthor);

            return Ok(author);
        }

        [HttpPut("{authorId:int}", Name = "update-author")]
        public async Task<IActionResult> UpdateAuthor(int authorId, UpdateAuthorDTO updateAuthor)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<Author>();
            await adminServiceManager.Author.UpdateAuthor(authorId, updateAuthor);
            return NoContent();
        }

        [HttpGet("{authorId:int}", Name = "get-Auhthor")]
        public async Task<IActionResult> GetAuthorById(int authorId)
        {
            var author = await adminServiceManager.Author.GetAuthor(authorId, true);
            return Ok(author);
        }

        [HttpGet(Name = "GetAllAuthor")]
        public async Task<IActionResult> GetAllAuthor()
        {
            var authors = await adminServiceManager.Author.GetAll(true);
           return Ok(authors);
        }

        

        [HttpDelete]
        public async Task<IActionResult> DeleteAuhtor(int authorId)
        {
            await adminServiceManager.Author.DeleteAuthor(authorId);
            return NoContent();
        }
    }
}
