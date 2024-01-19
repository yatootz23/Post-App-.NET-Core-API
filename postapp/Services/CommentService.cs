using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using postapp.Data;
using postapp.Dtos;
using postapp.Interfaces;
using postapp.Models;

namespace postapp.Services
{
    public class CommentService : ICommentService
    {
        private readonly AppDbContext _AppDbContext;
        public CommentService(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public async Task<List<Comment>> GetComments()
        {
            return await _AppDbContext.comment.ToListAsync();
        }

        public async Task<Comment?> GetComment(int Id)
        {
            return await _AppDbContext.comment.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Comment> CreateComment(Comment comment, int postid)
        {
            comment.Post = await _AppDbContext.post.FindAsync(postid);
            await _AppDbContext.comment.AddAsync(comment);
            await _AppDbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> UpdateComment(int id, UpdateCommentDto updateCommentDto)
        {
            var comment = await _AppDbContext.comment.FirstOrDefaultAsync(x => x.Id == id);
            if(comment == null){
                return null;
            }
            if(updateCommentDto.Content != null && comment.Content != updateCommentDto.Content){
                comment.Content = updateCommentDto.Content;
            }
            await _AppDbContext.SaveChangesAsync();
            return comment;
        }

        public async Task<Comment?> DeleteComment(int id)
        {
            var comment = await _AppDbContext.comment.FirstOrDefaultAsync(x => x.Id == id);
            if(comment == null){
                return null;
            }
            _AppDbContext.Remove(comment);
            await _AppDbContext.SaveChangesAsync();
            return comment;
        }
    }
}