using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract
{
    public interface IBuyerRepository
    {
        void AddBuyer(Buyer buyer);
        Task<Buyer> GetBuyerAsync(Guid buyerId, bool trackChanges);
        Task<Buyer> SignInAsync(string phoneNumber, string password, bool trackChanges);
        void UpdateBuyer(Buyer buyer);
    }
}
