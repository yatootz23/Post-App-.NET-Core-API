using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postapp.Dtos
{
    public class UpdatePostDto
    {
        public string? post_title { get; set; } = null;
        public string? content { get; set; } = null;
    }
}