using Entities.Models.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Seller
{
    public class UpdateSellerDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public EGender BuyerGender { get; set; }
        public ESellerStatus Status { get; set; }
        public string? ImageUrl { get; set; }
        public int? publisherId { get; set; }
        public ESellerSteps Steps { get; set; }

    }
}
