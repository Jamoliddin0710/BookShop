using Entities.Models.Enums;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelView
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public EOrderStatus OrderStatus { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
        public ICollection<OrderBookDTO>? OrderBooks { get; set; }
    }
}

