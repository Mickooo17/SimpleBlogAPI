using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.DTO.Request;
using SimpleBlog.DTO.Response;
using SimpleBlog.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;

        public PostsController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        [HttpGet("{slug}")]
        public async Task<ActionResult<GetPostResponse>> GetPost(string slug)
        {
            var result = await _postRepository.GetPost(slug);
            if (result.BlogPost == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<GetPostsResponse>> GetPosts([FromQuery] GetPostsRequest request)
        {
            return Ok(await _postRepository.GetPosts(request));
        }


        [HttpPost]
        public async Task<ActionResult<GetPostResponse>> CreatePost([FromBody] CreatePostRequest request)
        {
            return Ok(await _postRepository.CreatePost(request));
        }

        [HttpPut("{slug}")]
        public async Task<ActionResult<GetPostResponse>> UpdatePost(string slug, [FromBody] UpdatePostRequest request)
        {
            var result = await _postRepository.UpdatePost(slug, request);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{slug}")]
        public async Task<ActionResult<bool>> DeletePost(string slug)
        {
            var result = await _postRepository.DeletePost(slug);
            if (result == false)
                return NotFound(result);

            return Ok(result);
        }
    }
}
