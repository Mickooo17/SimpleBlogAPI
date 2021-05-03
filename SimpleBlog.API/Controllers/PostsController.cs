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
        public ActionResult<GetPostResponse> GetPost(string slug)
        {
            var result = _postRepository.GetPost(slug);
            if (result.BlogPost == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public ActionResult<GetPostsResponse> GetPosts([FromQuery] GetPostsRequest request)
        {
            return Ok( _postRepository.GetPosts(request));
        }


        [HttpPost]
        public ActionResult<GetPostResponse> CreatePost([FromBody] CreatePostRequest request)
        {
            return Ok(_postRepository.CreatePost(request));
        }

        [HttpPut("{slug}")]
        public ActionResult<GetPostResponse> UpdatePost(string slug, [FromBody] UpdatePostRequest request)
        {
            var result = _postRepository.UpdatePost(slug, request);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{slug}")]
        public ActionResult<bool> DeletePost(string slug)
        {
            var result = _postRepository.DeletePost(slug);
            if (result == false)
                return NotFound(result);

            return Ok(result);
        }
    }
}
