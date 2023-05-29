using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author
    {
        [Column("authorId")]
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? BIO { get; set; }
        public List<Book>? Books { get; set;} 
    }
}
