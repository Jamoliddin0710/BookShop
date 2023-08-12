﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopFront.DTO
{
    public class UpdateAuthorDTO
    {
        public string? FullName { get; set; }
        [Required]
        public string? BIO { get; set; }
    }
}
