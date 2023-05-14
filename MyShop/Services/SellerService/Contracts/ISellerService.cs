using Entities.DTO.Buyer;
using Entities.DTO.User;
using Entities.Models;
using Entities.ModelView;
using System.Security.Claims;

namespace MyShop.Services.SellerService.Contracts
{
    public interface ISellerService
    {
        Task<UserAuthInfo> SignUp(byte[] key, CreateBuyerDTO buyer);
        Task<BuyerDTO> GetBuyerAsync(ClaimsPrincipal claims, bool trackChanges);
        Task<UserAuthInfo> SignInAsync(byte[] key, UserCredentials userCredentials, bool trackChanges);
        Task<object> RefreshToken(byte[] key, TokenModel tokenModel, bool trackChanges);
        Task UpdateBuyerasync(ClaimsPrincipal claims, UpdateBuyerDTO buyerDTO, bool trackChanges);
    }
}
