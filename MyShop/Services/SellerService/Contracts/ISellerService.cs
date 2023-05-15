using Entities.DTO.Buyer;
using Entities.DTO.Seller;
using Entities.DTO.User;
using Entities.Models;
using Entities.ModelView;
using System.Security.Claims;

namespace MyShop.Services.SellerService.Contracts
{
    public interface ISellerService
    {
        Task<UserAuthInfo> SignUp(byte[] key, CreateSellerDTO seller);
        Task<SellerDTO> GetSellerAsync(ClaimsPrincipal claims, bool trackChanges);
        Task<UserAuthInfo> SignInAsync(byte[] key, UserCredentials userCredentials, bool trackChanges);
        Task<object> RefreshToken(byte[] key, TokenModel tokenModel, bool trackChanges);
        Task UpdateSellerasync(ClaimsPrincipal claims, UpdateSellerDTO sellerDTO, bool trackChanges);
    }
}
