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
        Task<GetPostsResponse> GetPosts(GetPostsRequest request);
        Task<GetPostResponse> GetPost(string slug);
        Task<GetPostResponse> CreatePost(CreatePostRequest request);
        Task<GetPostResponse> UpdatePost(string slug, UpdatePostRequest request);
        Task<bool> DeletePost(string slug);
    }
}
