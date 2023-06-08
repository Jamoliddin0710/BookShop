﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string? FileName { get; set; }
        public string? ContentType { get; set; }
        public byte[] ImageData { get; set; }
        public int? bookId { get; set; }
        [ForeignKey(nameof(bookId))]
        public Book? Book { get; set; }
    }
}
