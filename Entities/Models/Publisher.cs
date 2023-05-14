using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Publisher
    {
        [Column("publisherId")]
        public int Id { get; set; } 
        public string Name { get; set; }
        public ICollection<BookPublisher> BookPublishers { get; set; }
    }
}
