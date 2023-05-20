﻿using Entities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ModelView
{
    public class AuthorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? BIO { get; set; }
       [JsonIgnore]
        public List<BookDTO> Books { get; set; }
    }
}
