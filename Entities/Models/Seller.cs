using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Seller
    {
        [Column("sellerId")]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public EGender BuyerGender { get; set; }
        public EUserRole Role { get; set; }
        public ESellerStatus Status { get; set; }
        public string? ImageUrl { get; set; }
        public int? publisherId { get; set; }
        [ForeignKey(nameof(publisherId))]
        public Publisher? Publisher { get; set; }
        public ESellerSteps Steps { get; set; }
    }
}

