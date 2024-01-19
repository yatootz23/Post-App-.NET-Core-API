using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using postapp.Dtos;

namespace postapp.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string post_title { get; set; } = string.Empty;

        public string content { get; set; } = string.Empty;
        
        public DateTime date_posted { get; set; } = DateTime.UtcNow;

        public int authorid { get; set; } = 0;

        public List<Comment>? Comments {get; set; } = new List<Comment>();
        
        
    }
}