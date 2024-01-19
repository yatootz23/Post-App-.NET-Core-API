using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using postapp.Dtos;
using postapp.Interfaces;
using postapp.Mappers;

namespace postapp.Controllers
{
    [Route("comments")]
    [ApiController]
    public class CommentController:ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;

        public CommentController(ICommentService commentService, IPostService postService)
        {  
           _commentService = commentService; 
            _postService = postService; 
        }

        [HttpGet]
        public async Task<IActionResult> GetComments(){
            var comments = await _commentService.GetComments();
            var commentDto = comments.Select(s => s.ToCommentDto());
            return Ok(commentDto.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id){
            var comment = await _commentService.GetComment(id);
            if (comment == null){
                return NotFound();
            }            
            return Ok(comment.ToCommentDto());
        }

        [HttpPost("{PostId}")]
        public async Task<IActionResult> CreateComment([FromRoute] int PostId, CreateCommentDto createCommentDto){
            if(!await _postService.PostExists(PostId)){
                return BadRequest("Post does not exist");
            }
            var comment = createCommentDto.CreateCommentFromDto(PostId);
            await _commentService.CreateComment(comment, PostId);
            return Ok(comment);
        }

        [HttpPut("{id}")]
         public async Task<IActionResult> UpdateComment([FromRoute] int id, [FromBody]UpdateCommentDto updateCommentDto){
            if(await _commentService.UpdateComment(id,updateCommentDto) == null){
                return NotFound();
            }
            return Ok();
         }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment([FromRoute] int id){
            if(await _commentService.DeleteComment(id) == null){
                return NotFound();
            }
            return Ok();
        }
    }
}