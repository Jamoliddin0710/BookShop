using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class BuyerRepository : RepositoryBase<Buyer>, IBuyerRepository
    {
        public BuyerRepository(RepositoryContext context) : base(context)
        {
        }

        public void AddBuyer(Buyer buyer) => Create(buyer);

        public async Task<Buyer> GetBuyerAsync(Guid buyerId, bool trackChanges)
            => await FindByCondition(buyer => buyer.Id == buyerId, trackChanges)
            .SingleOrDefaultAsync();

        public async Task<Buyer> SignInAsync(string phoneNumber, string password, bool trackChanges)
            => await FindByCondition(buyer => buyer.Password.Equals(password) && buyer.PhoneNumber.Equals(phoneNumber), trackChanges).SingleOrDefaultAsync();

        public void UpdateBuyer(Buyer buyer) => Update(buyer);
    }
}
