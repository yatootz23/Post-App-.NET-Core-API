using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postapp.Dtos
{
    public class PostDto
    {
        public int Id { get; set; }

        public string? post_title { get; set; }

        public string? content { get; set; }
        
        public DateTime date_posted { get; set; }

        public List<CommentDto> Comments {get; set; }
    }
}