using Entities.Models.Enums;
using Entities.ModelView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO.Order
{
    public class CreateOrderDTO
    {
        public ICollection<CreateOrderBook>? OrderBooks { get; set; }
    }
}
