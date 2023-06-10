using Contracts.RepositoryContract;
using Contracts.ServiceContract.AdminServiceContract;
using Entities.DTO.Image;
using Entities.Exceptions;
using Entities.Models;
using Entities.Models.Enums;
using Entities.ModelView;
using Mapster;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Extensions;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


namespace MyShop.Services.AdminService
{
    public class ImageService : IImageService
    {
        private readonly IRepositoryManager repositoryManager;

        public ImageService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<List<ImageDTO>> AddImage(int bookId, CreateImageDTO createImage, bool trackChanges)
        {
            var book = await repositoryManager.Book.GetBookById(bookId, trackChanges);
            if (book is null)
                throw new EntityNotFoundException<Book>();

            var imagelist = new List<ImageDTO>();

            if (createImage.BookImage is not null || createImage.BookImage.Count() > 0)
            {
                foreach (IFormFile file in createImage.BookImage)
                {
                    string fileName = await file.SaveFile(EImageFolder.Book.ToString());
                    var image = new Image()
                    {
                        bookId = book.Id,
                        ImageUrl = fileName,
                    };
                    repositoryManager.Image.AddImage(image);
                    await repositoryManager.SaveAsync();
                    imagelist ??= new List<ImageDTO>();
                    imagelist.Add(image.Adapt<ImageDTO>());
                }
            }
            return imagelist;
        }

        
        public async Task DeleteImage(int imageId)
        {
            var image = await repositoryManager.Image.GetImageAsync(imageId, false);
            if (image is null)
                throw new EntityNotFoundException<Image>();

            repositoryManager.Image.DeleteImage(image);
            await repositoryManager.SaveAsync();
        }

        public async Task<IEnumerable<ImageDTO>> GetAllImages(bool trackChanges)
        {
            var images = repositoryManager.Image.GetAllImages(trackChanges);
            if (images is null || images.Count() == 0)
                return new List<ImageDTO>();

            return images.Adapt<IEnumerable<ImageDTO>>();
        }

        public async Task<ImageDTO> GetImageById(int iamgeId, bool trackChanges)
        {
            var image = await repositoryManager.Image.GetImageAsync(iamgeId, trackChanges);
            if (image is null)
                throw new EntityNotFoundException<Image>();

            return image.Adapt<ImageDTO>();
        }
    }
}
