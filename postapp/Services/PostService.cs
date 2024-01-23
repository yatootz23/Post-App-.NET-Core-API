using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using postapp.Data;
using postapp.Dtos;
using postapp.Helpers;
using postapp.Interfaces;
using postapp.Mappers;
using postapp.Models;

namespace postapp.Services
{
    public class PostService : IPostService
    {
        private readonly AppDbContext _AppDbContext;

        public PostService(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
        }

        public async Task<List<Post>> GetAllPost(QueryObject query){
            var posts = _AppDbContext.post.Include(c => c.Comments).AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.post_title)){
                posts = posts.Where(p => p.post_title.Contains(query.post_title));
            }
            if(!string.IsNullOrWhiteSpace(query.content)){
                posts = posts.Where(p => p.content.Contains(query.content));
            }

            posts = posts.OrderByDescending(p => p.date_posted);

            return await posts.ToListAsync();

        }

        public async Task<Post?> GetPost(int id){
            return await _AppDbContext.post.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Post> CreatePost(Post post){
            await _AppDbContext.post.AddAsync(post);
            await _AppDbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> UpdatePost(int id, UpdatePostDto updatePostDto)
        {
            var post = await _AppDbContext.post.FirstOrDefaultAsync(x => x.Id == id);
            if(post == null){
                return null;
            }
            if(updatePostDto.post_title != null && post.post_title != updatePostDto.post_title){
                post.post_title = updatePostDto.post_title;
            }
            if(updatePostDto.content != null && post.content != updatePostDto.content){
                post.content = updatePostDto.content;
            }
            await _AppDbContext.SaveChangesAsync();
            return post;
        }

        public async Task<Post?> DeletePost(int id){
            var deletePost = await _AppDbContext.post.FirstOrDefaultAsync(x => x.Id == id);
            if (deletePost == null){
                return null;
            }
            _AppDbContext.post.Remove(deletePost);
            await _AppDbContext.SaveChangesAsync();
            return deletePost;

        }

        public Task<bool> PostExists(int id)
        {
            return _AppDbContext.post.AnyAsync(s => s.Id == id);
        }
    }
}