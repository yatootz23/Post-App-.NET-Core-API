using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace postapp.Dtos
{
    public class CreatePostDto
    {
    [Required]
        public string? post_title { get; set; }

    [Required]
        public string? content { get; set; }
    }
}