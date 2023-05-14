using Contracts;
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
    public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
    {
        public SellerRepository(RepositoryContext context) : base(context)
        {
        }

        public void AddSeller(Seller seller) => Create(seller);

        public async Task<Seller> GetSellerById(Guid sellerId, bool trackChanges)
        => await FindByCondition(seller => seller.Id == sellerId, trackChanges).SingleOrDefaultAsync();

        public async Task<Seller> Signin(string phonenumber, string password, bool trackChanges) =>
                   await FindByCondition(seller => seller.Equals(phonenumber) && seller.Equals(password), trackChanges)
                   .SingleOrDefaultAsync();

        public void UpdateSeller(Seller seller) => Update(seller);
    }
}
