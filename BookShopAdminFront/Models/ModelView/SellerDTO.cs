
using BookShopAdminFront.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopFront.Models.ModelView
{
    public class SellerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public EGender BuyerGender { get; set; }
        public string? ImageUrl { get; set; }
        public string PublisherName { get; set; }
    }
}
