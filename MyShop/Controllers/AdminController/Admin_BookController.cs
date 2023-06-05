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

        private readonly IAdminServiceManager sellerServiceManager;

        public Admin_BookController(IAdminServiceManager sellerServiceManager)
        {
            this.sellerServiceManager = sellerServiceManager;
        }

        [HttpPost(Name = "Add-Book")]
        public async Task<IActionResult> AddBook([FromForm] CreateBookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<CreateBookDTO>();

            var book = await sellerServiceManager.Book.AddBook(bookDTO);
            return Ok(book);
        }

        [HttpGet("api/Admin_Book/{bookId:int}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var book = await sellerServiceManager.Book.GetBookById(bookId, true);
            return Ok(book);
        }

        [HttpPut("{bookId:int}", Name = "update-book")]
        public async Task<IActionResult> UpdateBook([FromForm] int bookId, UpdateBookDTO bookDTO)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<UpdateBookDTO>();

            await sellerServiceManager.Book.UpdateBook(bookId, bookDTO);
            return NoContent();
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBook([FromQuery] BookFilterDTO bookFilter)
        {
            var books = await sellerServiceManager.Book.GetAllBooks(bookFilter, true);
            return Ok(books);
        }

    }
}
