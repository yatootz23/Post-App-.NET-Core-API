using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using postapp.Dtos;
using postapp.Models;

namespace postapp.Interfaces
{
    public interface ICommentService
    {
        Task<List<Comment>> GetComments();

        Task<Comment?> GetComment(int Id);

        Task <Comment> CreateComment(Comment comment, int postid);

        Task<Comment?> UpdateComment(int id, UpdateCommentDto updateCommentDto);

        Task<Comment?> DeleteComment(int id);
    }
}