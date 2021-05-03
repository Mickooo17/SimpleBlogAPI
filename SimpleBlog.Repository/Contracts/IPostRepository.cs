using SimpleBlog.DTO.Request;
using SimpleBlog.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Repository.Contracts
{
    public interface IPostRepository
    {
        GetPostsResponse GetPosts(GetPostsRequest request);
        GetPostResponse GetPost(string slug);
        GetPostResponse CreatePost(CreatePostRequest request);
        GetPostResponse UpdatePost(string slug, UpdatePostRequest request);
        bool DeletePost(string slug);
    }
}
