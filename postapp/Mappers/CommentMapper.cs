using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using postapp.Dtos;
using postapp.Models;

namespace postapp.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment){
            return new CommentDto{
                Id = comment.Id,
                Content = comment.Content,
                Date_Posted = comment.Date_Posted,
                AuthorId = comment.AuthorId,
                PostId = comment.PostId
            };
        }

        public static Comment CreateCommentFromDto(this CreateCommentDto createCommentDto, int id){
            return new Comment{
                Content = createCommentDto.Content,
                PostId = id
            };
        }
    }
}