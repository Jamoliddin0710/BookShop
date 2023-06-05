using Entities.DTO.Book;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.BuyerService.Contracts;

namespace MyShop.Controllers.BuyerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Buyer_BookController : ControllerBase
    {
        private readonly IBuyerServiceManager buyerServiceManager;

        public Buyer_BookController(IBuyerServiceManager buyerServiceManager)
        {
            this.buyerServiceManager = buyerServiceManager;
        }

        [HttpGet("api/Buyer/Book/{bookId:int}")]
        public async Task<IActionResult> GetBook(int bookId)
        =>Ok(await buyerServiceManager.Book.GetBookById(bookId, true));

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll([FromQuery]BookFilterDTO bookFilter)
        => Ok(await buyerServiceManager.Book.GetAllBooks(bookFilter,true));
    }
}
