﻿using BookShopFront.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopFront.DTO.Buyer
{
    public class UpdateBuyerDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNumber { get; set; }
        public EGender BuyerGender { get; set; }
    }

}

