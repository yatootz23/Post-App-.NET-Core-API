using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using postapp.Dtos;
using postapp.Models;

namespace postapp.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToPostDto(this Post postModel){
            return new PostDto{
                Id = postModel.Id,
                post_title = postModel.post_title,
                content = postModel.content,
                date_posted = postModel.date_posted,
                Comments = postModel.Comments.Select(c => c.ToCommentDto()).ToList()
            };
        }

        public static Post CreatePostFromDto(this CreatePostDto createPostDto){
            return new Post{
                post_title = createPostDto.post_title,
                content = createPostDto.content
            };
        }
    }
}