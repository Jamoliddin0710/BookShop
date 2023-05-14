using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface ISellerRepository
    {
        void AddSeller(Seller seller);
        Task<Seller> Signin(string phonenumber, string password , bool trackChanges);
        void UpdateSeller(Seller seller);
        Task<Seller> GetSellerById(Guid sellerId, bool trackChanges);
    }
}
