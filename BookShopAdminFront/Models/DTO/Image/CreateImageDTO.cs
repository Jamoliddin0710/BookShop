
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Image
{
    public class CreateImageDTO
    {
        public IFormFileCollection? BookImage { get; set; }
        //public EImageFolder ImageFolder { get; set; }
    }
}
