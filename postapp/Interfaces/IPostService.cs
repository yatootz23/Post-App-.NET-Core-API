using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using postapp.Dtos;
using postapp.Models;

namespace postapp.Interfaces
{
    public interface IPostService
    {
        Task<List<Post>> GetAllPost();

        Task<Post?> GetPost(int id);

        Task<Post> CreatePost(Post post);

        Task<Post?> UpdatePost(int id, UpdatePostDto updatePostDto);

        Task<Post?> DeletePost(int id);

        Task<bool> PostExists(int id);
    }
}