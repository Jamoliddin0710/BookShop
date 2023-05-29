using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract
{
    public interface IPublisherRepository
    {
        void AddPublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeleteAllPublisher();
        void DeletePublisher(Publisher publisher);
        Task<Publisher> GetPublisherById(int publisherId, bool trackChanges);
        IQueryable<Publisher> GetAllPublisher(bool tracking);
    }
}
