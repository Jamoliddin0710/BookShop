using Contracts.RepositoryContract;
using Entities;
using Entities.Models;
using Entities.ModelView;
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

        public void DeleteSeller(Seller seller) => Delete(seller);

        public IQueryable<Seller> GetAllSellers(bool trackChanges)
        => FindAll(trackChanges).Include(seller => seller.Publisher)
            .OrderBy(k => k.FirstName);


        public async Task<Seller> GetSellerById(Guid sellerId, bool trackChanges)
        => await FindByCondition(seller => seller.Id == sellerId, trackChanges).SingleOrDefaultAsync();

        public async Task<Seller> GetSellerByPhone(string phone, bool trackChanges)
         => await FindByCondition(seller => seller.PhoneNumber.Equals(phone), trackChanges).SingleOrDefaultAsync();
        public async Task<Seller> GetSellerByPhoneNumber(string phone, bool trackChanges)
         => await FindByCondition(seller => seller.PhoneNumber.Equals(phone), trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Seller> Signin(string phonenumber, string password, bool trackChanges) =>
                   await FindByCondition(seller => seller.Equals(phonenumber) && seller.Equals(password), trackChanges)
                   .SingleOrDefaultAsync();

        public void UpdateSeller(Seller seller) => Update(seller);
    }
}
