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
    public class PublisherRepository : RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(RepositoryContext context) : base(context)
        {
        }

        public void AddPublisher(Publisher publisher) => Create(publisher);

        public void DeleteAllPublisher() => DeleteAll();

        public void DeletePublisher(Publisher publisher) => DbSet.Remove(publisher);

        public IQueryable<Publisher> GetAllPublisher(bool tracking) =>
             FindAll(tracking).Include(p => p.Books).OrderBy(p => p.Name);

        public async Task<Publisher> GetPublisherById(int publisherId, bool trackChanges) =>
          await FindByCondition(publisher => publisher.Id == publisherId, trackChanges).SingleOrDefaultAsync();

        public void UpdatePublisher(Publisher publisher) => Update(publisher);
    }
}
