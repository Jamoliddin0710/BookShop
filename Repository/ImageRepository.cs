using Contracts.RepositoryContract;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ImageRepository : RepositoryBase<Image>, IImageRepository
    {
        public ImageRepository(RepositoryContext context) : base(context)
        {
        }

        public void AddImage(Image image) => Create(image);

        public void DeleteImage(Image image) => Delete(image);

        public IQueryable<Image> GetAllImages(bool trackChanges)
        => FindAll(trackChanges).Include(img => img.Book);
        public async Task<Image> GetImageAsync(int imageId, bool trackChanges)
        => await FindByCondition(img => img.Id == imageId, trackChanges).Include(img => img.Book).SingleOrDefaultAsync();
    }
}
