using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopAdminFront.Models.DTO.Genre
{
    public class UpdateGenreDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
