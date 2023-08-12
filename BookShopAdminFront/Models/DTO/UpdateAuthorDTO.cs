
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopAdminFront.Models.DTO
{
    public class UpdateAuthorDTO
    {
        public string? FullName { get; set; }
        [Required]
        [StringLength(5, ErrorMessage = "FullName length can't be more than 8.")]
        public string? BIO { get; set; }
    }
}
