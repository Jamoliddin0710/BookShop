using Entities.DTO.Author;
using Entities.DTO.Genre;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Services.AdminService;
using MyShop.Services.AdminService.Contracts;

namespace MyShop.Controllers.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class Admin_GenreController : ControllerBase
    {

        private readonly IAdminServiceManager adminServiceManager;

        public Admin_GenreController(IAdminServiceManager adminServiceManager)
        {
            this.adminServiceManager = adminServiceManager;
        }

        [HttpPost(Name = "add-Genre")]
        public async Task<IActionResult> AddGenre(CreateGenreDTO createGenre)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<Genre>();
            var genre = await adminServiceManager.Genre.CreateGenre(createGenre);

            return Ok(genre);
        }

        [HttpPut("{genreId:int}", Name = "update-genre")]
        public async Task<IActionResult> UpdateGenre(int genreId, UpdateGenreDTO updateGenre)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<Author>();
            await adminServiceManager.Genre.UpdateGenre(genreId, updateGenre);
            return NoContent();
        }

        [HttpGet("{genreId:int}", Name = "getAuhthor")]
        public async Task<IActionResult> GetGenreById(int genreId)
        {
            var genre = await adminServiceManager.Genre.GetGenreById(genreId, true);

            return Ok(genre);
        }

        [HttpGet(Name = "GetAllGenre")]
        public async Task<IActionResult> GetGenre()
         => Ok(await adminServiceManager.Genre.GetAllGenre(true));

        [HttpDelete("{genreId:int}")]
        public async Task<IActionResult> DeleteGenre(int genreId)
        {
            await adminServiceManager.Genre.DeleteGenre(genreId);
            return NoContent();
        }
    }
}
