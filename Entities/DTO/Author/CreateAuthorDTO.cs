
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Author
{
    public class CreateAuthorDTO
    {
        [Required]
        public string FullName { get; set; }
        public string? BIO { get; set; }
    }
}
