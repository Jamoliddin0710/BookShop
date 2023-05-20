using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Seller
{
    public class CreateSellerDTO
    {
        [Required]
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        public EGender SellerGender { get; set; }
        public ESellerStatus Status { get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        public int? publisherId { get; set; }
    }
}
