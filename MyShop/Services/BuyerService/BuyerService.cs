using Contracts;
using Entities.DTO.Buyer;
using Entities.DTO.User;
using Entities.Exceptions;
using Entities.Models;
using Entities.ModelView;
using Mapster;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Logger;
using MyShop.Services.BuyerService.Contracts;
using Repository;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace MyShop.Services.BuyerService
{
    public class BuyerService : IBuyerService
    {
        private readonly MyShop.Logger.ILogger logger;
        private readonly IRepositoryManager repositoryManager;
        public BuyerService(IRepositoryManager repositoryManager)
        {
            logger = new FileLogger();
            this.repositoryManager = repositoryManager;
        }

        public async Task<UserAuthInfo> SignUp(byte[] key, CreateBuyerDTO createBuyer)
        {
            if (createBuyer is null)
                throw new EntityNotValidException<CreateBuyerDTO>();

            var buyer = createBuyer.Adapt<Buyer>();
            buyer.Role = Entities.Models.Enums.EUserRole.Buyer;
            repositoryManager.Buyer.AddBuyer(buyer);
            await repositoryManager.SaveAsync();

            var authinfo = GenerateToken(key, buyer);
            return authinfo;
        }

        public async Task<BuyerDTO> GetBuyerAsync(ClaimsPrincipal claims, bool trackChanges)
        {
            try
            {
                var buyerId = Guid.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
                var buyer = await repositoryManager.Buyer.GetBuyerAsync(buyerId, trackChanges);
                return buyer.Adapt<BuyerDTO>() ?? throw new EntityNotFoundException<Buyer>();
            }
            catch (Exception ex)
            {
                logger.Log(ex.Message);
                throw new EntityNotFoundException<Buyer>();
            }
        }

        public Task<object> RefreshToken(byte[] key, TokenModel tokenModel, bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAuthInfo> SignInAsync(byte[] key, UserCredentials userCredentials, bool trackChanges)
        {
            var buyer = await repositoryManager.Buyer.SignInAsync(userCredentials.PhoneNumber, userCredentials.Password, trackChanges);
            if (buyer is null)
                throw new EntityNotFoundException<Buyer>();

            var auth = GenerateToken(key, buyer);
            return auth;
        }

        public async Task UpdateBuyerasync(ClaimsPrincipal claims, UpdateBuyerDTO buyerDTO, bool trackChanges)
        {
            try
            {
                var buyerId = Guid.Parse(claims.FindFirstValue(ClaimTypes.NameIdentifier));
                var buyer = await repositoryManager.Buyer.GetBuyerAsync(buyerId, trackChanges);
                if(buyer is null)
                    throw new EntityNotFoundException<Buyer>();

                buyer.FirstName = buyerDTO.FirstName;
                buyer.LastName = buyerDTO.LastName;
                buyer.PhoneNumber = buyerDTO.PhoneNumber;
                buyer.BuyerGender = buyerDTO.BuyerGender;
                repositoryManager.Buyer.UpdateBuyer(buyer);
                await repositoryManager.SaveAsync();
            }
            catch(Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }


        private UserAuthInfo GenerateToken(byte[] key, Buyer buyer)
        {
            var tokendesc = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity
                (
                    new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier , buyer.Id.ToString()),
                        new Claim(ClaimTypes.GivenName , buyer.FirstName),
                        new Claim(ClaimTypes.Role, buyer.Role.ToString()),
                        new Claim(ClaimTypes.MobilePhone, buyer.PhoneNumber),
                        new Claim(ClaimTypes.Role , buyer.Role.ToString()),
                    }

                ),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };
            var token = new JwtSecurityTokenHandler().CreateToken(tokendesc);

            var x = buyer.Adapt<UserCredentials>();
            var authInfo = new UserAuthInfo()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserCredentials = buyer.Adapt<UserDTO>(),
            };
            if (string.IsNullOrEmpty(authInfo.Token))
                throw new EntityUnotharizeException<Buyer>();
            return authInfo;
        }

        private string GenerateRefreshToken()
        {
            var random = new Byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(random);

            return Convert.ToBase64String(random);
        }

    }
}
