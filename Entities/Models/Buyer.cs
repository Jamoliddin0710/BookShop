using Entities.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Buyer
    {
        [Column("buyerId")]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public EGender BuyerGender { get; set; }
        public EUserRole Role = EUserRole.User;
        public EBuyerSigninStatus BuyerSigninStatus { get; set; }
    }
}
