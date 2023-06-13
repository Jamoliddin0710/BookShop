using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.RepositoryContract
{
    public interface ICartRepository
    {
        void CreateCart(Cart cart);
        void UpdateCart(Cart cart);
        void DeleteCart(Cart cart);
        Task<Cart> GetCartById(int cartId, bool trackChanges);
        IQueryable<Cart> GetAllCart(bool trackChanges);
    }
}
