
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopFront.Models.ModelView
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string? ImageUrl { get; set; }
    }
}
