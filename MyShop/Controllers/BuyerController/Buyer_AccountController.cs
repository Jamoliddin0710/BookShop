﻿using Contracts;
using Entities.DTO.Buyer;
using Entities.DTO.User;
using Entities.Exceptions;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyShop.Services.BuyerService.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MyShop.Controllers.BuyerController
{
    [Authorize(Roles = "Buyer")]
    [Route("api/[controller]")]
    [ApiController]
    public class Buyer_AccountController : ControllerBase
    {
        private readonly IBuyerServiceManager service;
        public IOptions<AppSettings> options { get; }
        public Buyer_AccountController(IOptions<AppSettings> options, IBuyerServiceManager service)
        {
            this.options = options;
            this.service = service;
        }

        [HttpPost("sign-up")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUp([FromQuery] CreateBuyerDTO createBuyer)
        {
            if (!ModelState.IsValid)
                throw new EntityNotValidException<CreateBuyerDTO>();

            var key = System.Text.Encoding.UTF8.GetBytes(options.Value.SecretKey);

            var auth = await service.Buyer.SignUp(key, createBuyer);

            return Ok(auth);
        }

        [HttpPost("sign-in")]
        [AllowAnonymous]
        public async Task<IActionResult> SignIn([FromQuery] UserCredentials userCredentials, CancellationToken token)
        {
            if (!ModelState.IsValid)
                return BadRequest($"{typeof(UserCredentials)} objects is null");

            var key = System.Text.Encoding.UTF8.GetBytes(options.Value.SecretKey);

            var authinfo = await service.Buyer.SignInAsync(key, userCredentials, true);

            return Ok(authinfo);
        }


        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            var buyerDTO = await service.Buyer.GetBuyerAsync(User, trackChanges: false);
            return Ok(buyerDTO);
        }

        [HttpPut("edit-profile")]
        public async Task<IActionResult> EditProfileAsync(UpdateBuyerDTO updateBuyer)
        {
            await service.Buyer.UpdateBuyerasync(User, updateBuyer, true);
            return NoContent();
        }
    }
}

