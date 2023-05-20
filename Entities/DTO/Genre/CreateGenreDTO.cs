using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Genre
{
    public class CreateGenreDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
