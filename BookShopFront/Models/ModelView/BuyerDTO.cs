
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopFront.Models.ModelView
{
    public class BuyerDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public EGender BuyerGender { get; set; }
        public EBuyerSigninStatus BuyerSigninStatus { get; set; }
    }
}

