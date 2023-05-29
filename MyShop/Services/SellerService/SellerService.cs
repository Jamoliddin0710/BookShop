using Contracts.RepositoryContract;
using Entities.DTO.Buyer;
using Entities.DTO.Seller;
using Entities.DTO.User;
using Entities.Exceptions;
using Entities.Models;
using Entities.ModelView;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using MyShop.Logger;
using MyShop.Services.SellerService.Contracts;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyShop.Services.SellerService
{
    public class SellerService : ISellerService
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly MyShop.Logger.ILogger logger;
        public SellerService(IRepositoryManager repositoryManager)
        {
            logger = new FileLogger();
            this.repositoryManager = repositoryManager;
        }

        public async Task<UserAuthInfo> SignUp(byte[] key, CreateSellerDTO sellerDTO)
        {
            var seller = sellerDTO.Adapt<Seller>();
            repositoryManager.Seller.AddSeller(seller);
            await repositoryManager.SaveAsync();
            var authinfo = GenerateToken(key, seller);
            return authinfo;
        }

        public async Task<UserAuthInfo> SignInAsync(byte[] key, UserCredentials userCredentials, bool trackChanges)
        {
            var seller = await repositoryManager.Seller.Signin(userCredentials.PhoneNumber, userCredentials.Password, trackChanges);
            if (seller is null)
                throw new EntityNotFoundException<Seller>();
            var authinfo = GenerateToken(key, seller);
            return authinfo;
        }


        public async Task UpdateSellerasync(ClaimsPrincipal claims, UpdateSellerDTO sellerDTO, bool trackChanges)
        {
            try
            {
                var sellerId = Guid.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
                var seller = await repositoryManager.Seller.GetSellerById(sellerId, trackChanges);
                if (seller is null)
                    throw new EntityNotFoundException<Seller>();
                var config = new TypeAdapterConfig();
                config.ForType<UpdateSellerDTO, Seller>()
                    .IgnoreNullValues(true)
                    .BeforeMapping((src, dest) =>
                    {
                        dest.Id = seller.Id;
                        dest.PhoneNumber = seller.PhoneNumber;
                        dest.Password = seller.Password;
                        dest.Role = seller.Role;
                        dest.Token = seller.Token;
                    });
                var sellerupdate = sellerDTO.Adapt(seller, config);
                repositoryManager.Seller.UpdateSeller(sellerupdate);
                await repositoryManager.SaveAsync();
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                throw new EntityNotFoundException<Seller>();
            }
        }

        public async Task<SellerDTO> GetSellerAsync(ClaimsPrincipal claims, bool trackChanges)
        {
            try
            {
                var sellerId = Guid.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
                var seller = await repositoryManager.Seller.GetSellerById(sellerId, trackChanges);
                return seller is null ? throw new EntityNotFoundException<Seller>() : seller.Adapt<SellerDTO>();
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                throw new EntityNotFoundException<Seller>();
            }
        }

        public Task<object> RefreshToken(byte[] key, TokenModel tokenModel, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        private UserAuthInfo GenerateToken(byte[] key, Seller seller)
        {
            var tokendesc = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, seller.Id.ToString()),
                        new Claim(ClaimTypes.Name, seller.FirstName.ToString()),
                        new Claim(ClaimTypes.CookiePath, seller.Password),
                        new Claim(ClaimTypes.Role, seller.Role.ToString()),
                        new Claim(ClaimTypes.MobilePhone, seller.PhoneNumber),
                    }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), algorithm: SecurityAlgorithms.HmacSha256),
            };
            var createtoken = new JwtSecurityTokenHandler().CreateToken(tokendesc);
            var authinfo = new UserAuthInfo()
            {
                UserCredentials = seller.Adapt<UserDTO>(),
                Token = new JwtSecurityTokenHandler().WriteToken(createtoken),
            };
            if (string.IsNullOrEmpty(authinfo.Token))
                throw new Exception("error generate token");
            return authinfo;
        }

        public async Task<SellerDTO> GetSellerById(Guid sellerId, bool trackChanges)
        {
            var seller = await repositoryManager.Seller.GetSellerById(sellerId, trackChanges);
            if (seller is null)
                throw new EntityNotFoundException<Seller>();
            return seller.Adapt<SellerDTO>();

        }

        public async Task<List<SellerDTO>> GetAllSeller(bool trackChanges)
        {
            var sellers =  repositoryManager.Seller.GetAllSellers(trackChanges);
            if (sellers is null || !sellers.Any())
                return new List<SellerDTO>();
            return  sellers.Adapt<List<SellerDTO>>();
        }

        public async Task UpdateSeller(Guid sellerId, UpdateSellerDTO sellerDTO)
        {
            var seller = await repositoryManager.Seller.GetSellerById(sellerId, false);


            if (seller is null)
                throw new EntityNotFoundException<Seller>();

            var config = new TypeAdapterConfig();

            config.ForType<UpdateSellerDTO, Seller>()
                .IgnoreNullValues(true)
                .BeforeMapping((src, dest) =>
                {
                    dest.Id = seller.Id;
                    dest.PhoneNumber = seller.PhoneNumber;
                    dest.Password = seller.Password;
                    dest.Role = seller.Role;
                });

            var sellerUpdate = sellerDTO.Adapt(seller, config);
            repositoryManager.Seller.UpdateSeller(sellerUpdate);
            await repositoryManager.SaveAsync();
        }

        public async Task<SellerDTO> GetSellerByPhone(string phone, bool trackChanges)
        {
            var seller = await repositoryManager.Seller.GetSellerByPhone(phone, trackChanges);
            if (seller is null)
                throw new EntityNotFoundException<Seller>();
            return seller.Adapt<SellerDTO>();
        }

        public async Task DeleteSeller(Guid sellerId)
        {
            var seller = await repositoryManager.Seller.GetSellerById(sellerId, false);

            if (seller is null)
                throw new EntityNotFoundException<Seller>();
            repositoryManager.Seller.DeleteSeller(seller);
            await repositoryManager.SaveAsync();
        }
    }
}
