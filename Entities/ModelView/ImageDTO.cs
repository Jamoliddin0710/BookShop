using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelView
{
    public class ImageDTO
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public byte[] ImageData { get; set; }
        public string? ContentType { get; set; }
        public int? bookId { get; set; }
        public BookDTO? Book { get; set; }
    }
}
