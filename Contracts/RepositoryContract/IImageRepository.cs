using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract
{
    public interface IImageRepository
    {
        void AddImage(Image image);
        void DeleteImage(Image image);
        Task<Image> GetImageAsync(int imageId, bool trackChanges);
        IQueryable<Image> GetAllImages(bool trackChanges);
    }
}
