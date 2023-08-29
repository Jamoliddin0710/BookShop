using Entities.DTO.Book;
using Entities.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.AdminService.Contracts;

namespace MyShop.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_BookController : ControllerBase
    {

        private readonly IAdminServiceManager adminServiceManager;

        public Admin_BookController(IAdminServiceManager adminServiceManager)
        {
            this.adminServiceManager = adminServiceManager;
        }

        [HttpPost(Name = "Add-Book")]
        public async Task<IActionResult> AddBook(CreateBookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<CreateBookDTO>();

            var book = await adminServiceManager.Book.AddBook(bookDTO);
            return Ok(book);
        }

        [HttpGet("api/Admin_Book/{bookId:int}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var book = await adminServiceManager.Book.GetBookById(bookId, true);
            return Ok(book);
        }

        [HttpPut("{bookId:int}", Name = "update-book")]
        public async Task<IActionResult> UpdateBook([FromForm] int bookId, UpdateBookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<UpdateBookDTO>();

            await adminServiceManager.Book.UpdateBook(bookId, bookDTO);
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBook([FromQuery] BookFilterDTO bookFilter)
        {
            var books = await adminServiceManager.Book.GetAllBooks(bookFilter);
            return Ok(books);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBook(int bookId)
        {
            await adminServiceManager.Book.DeleteBook(bookId);
            return NoContent();
        }

    }
}
