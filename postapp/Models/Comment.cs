using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace postapp.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public int AuthorId { get; set; } = 0;
        public DateTime Date_Posted { get; set; } = DateTime.UtcNow;
        public int? PostId { get; set; }
        public Post? Post { get; set; }
        
        
        
        
    }
}