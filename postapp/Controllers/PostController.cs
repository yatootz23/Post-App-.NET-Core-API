using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using postapp.Data;
using postapp.Models;
using postapp.Mappers;
using postapp.Dtos;
using postapp.Interfaces;
using postapp.Helpers;

namespace postapp.Controllers
{
    [Route("posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPost([FromQuery] QueryObject query)
        {
           if(!ModelState.IsValid){
                return BadRequest();
            }
            var posts = await _postService.GetAllPost(query);
            var postDto = posts.Select(s => s.ToPostDto());
            return Ok(postDto.ToList());
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetPost([FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest();
            }
            var post = await _postService.GetPost(id);
            if (post == null){
                return NotFound();
            }            
            return Ok(post.ToPostDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePostDto newPost){
            if(!ModelState.IsValid){
                return BadRequest();
            }
            var postModel = newPost.CreatePostFromDto();
            await _postService.CreatePost(postModel); 
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePost([FromRoute] int id, [FromBody] UpdatePostDto updatePost){
            if(!ModelState.IsValid){
                return BadRequest();
            }
            if(await _postService.UpdatePost(id, updatePost) == null){
                return NotFound();
            }
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePost([FromRoute] int id){
            if(!ModelState.IsValid){
                return BadRequest();
            }
            if(await _postService.DeletePost(id) == null){
                return NotFound();
            }
            return Ok();
        }
    }
}