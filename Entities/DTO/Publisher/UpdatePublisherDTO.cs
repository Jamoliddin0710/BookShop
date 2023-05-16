using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Publisher
{
    public class UpdatePublisherDTO
    {
        [Required]
        public string Name { get; set; }
    }
}
