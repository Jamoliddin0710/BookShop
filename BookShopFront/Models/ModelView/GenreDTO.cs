﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShopFront.Models.ModelView
{
    public class GenreDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BookDTO> Books { get; set; }
    }
}
