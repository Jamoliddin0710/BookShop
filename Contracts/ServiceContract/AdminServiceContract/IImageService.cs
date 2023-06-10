using Entities.DTO.Image;
using Entities.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.ServiceContract.AdminServiceContract
{
    public interface IImageService
    {
        Task<List<ImageDTO>> AddImage(int bookId, CreateImageDTO createImage, bool trackChanges);
        Task DeleteImage(int imageId);
        Task<ImageDTO> GetImageById(int iamgeId, bool trackChanges);
        Task<IEnumerable<ImageDTO>> GetAllImages(bool trackChanges);
    }
}
