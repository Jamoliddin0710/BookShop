using Contracts.RepositoryContract;
using Contracts.ServiceContract.AdminServiceContract;
using Entities.DTO.Image;
using Entities.Exceptions;
using Entities.Models;
using Entities.ModelView;
using Mapster;
using System.IO;


namespace MyShop.Services.AdminService
{
    public class ImageService : IBookImageService
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
                foreach (var image in createImage.BookImage)
                {
                    var imagemodel = new Entities.Models.Image();
                    imagemodel.FileName = image.FileName;
                    imagemodel.bookId = bookId;
                    imagemodel.ContentType = image.ContentType;

                    using (var stream = new MemoryStream())
                    {
                        await image.CopyToAsync(stream);
                        imagemodel.ImageData = stream.ToArray();
                    }
                    book.Images ??= new List<Image> { imagemodel };
                    imagelist.Add(imagemodel.Adapt<ImageDTO>());
                    repositoryManager.Image.AddImage(imagemodel);
                    await repositoryManager.SaveAsync();
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
