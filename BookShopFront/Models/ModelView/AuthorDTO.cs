
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopFront.Models.ModelView
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? BIO { get; set; }
        public List<BookDTO> Books { get; set; }
    }
}
