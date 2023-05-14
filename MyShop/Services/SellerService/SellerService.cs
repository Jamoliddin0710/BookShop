using Contracts;
using Entities.DTO.Buyer;
using Entities.DTO.User;
using Entities.Models;
using Entities.ModelView;
using MyShop.Services.SellerService.Contracts;
using System.Security.Claims;

namespace MyShop.Services.SellerService
{
    public class SellerService : ISellerService
    {
        private readonly IRepositoryManager repository;

        public SellerService(IRepositoryManager repository)
        {
            this.repository = repository;
        }

        public Task<BuyerDTO> GetBuyerAsync(ClaimsPrincipal claims, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<object> RefreshToken(byte[] key, TokenModel tokenModel, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<UserAuthInfo> SignInAsync(byte[] key, UserCredentials userCredentials, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public Task<UserAuthInfo> SignUp(byte[] key, CreateBuyerDTO buyer)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBuyerasync(ClaimsPrincipal claims, UpdateBuyerDTO buyerDTO, bool trackChanges)
        {
            throw new NotImplementedException();
        }
    }
}
