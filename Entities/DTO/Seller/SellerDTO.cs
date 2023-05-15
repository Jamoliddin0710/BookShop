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
    public class SellerDTO
    {
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public EGender BuyerGender { get; set; }
        public string? ImageUrl { get; set; }
        public int? publisherId { get; set; }
        [ForeignKey(nameof(publisherId))]
        public Publisher? Publisher { get; set; }
    }
}
