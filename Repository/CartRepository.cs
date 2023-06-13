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
    public class CartRepository : RepositoryBase<Cart>, ICartRepository
    {
        public CartRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateCart(Cart cart) => Create(cart);

        public void UpdateCart(Cart cart) => Update(cart);

        public void DeleteCart(Cart cart) => Delete(cart);

        public async Task<Cart> GetCartById(int cartId, bool trackChanges)
        => await FindByCondition(cart => cart.Id == cartId, trackChanges)
                .Include(cart => cart.Buyer).Include(cart => cart.CartBooks).SingleOrDefaultAsync();

        public IQueryable<Cart> GetAllCart(bool trackChanges)
        => FindAll(trackChanges).Include(cart => cart.Buyer).Include(cart => cart.CartBooks);
    }
}
