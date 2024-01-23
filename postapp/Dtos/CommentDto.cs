using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace postapp.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public int AuthorId { get; set; } = 0;
        public DateTime Date_Posted { get; set; } = DateTime.Now;
        public int? PostId { get; set; }
    }
}