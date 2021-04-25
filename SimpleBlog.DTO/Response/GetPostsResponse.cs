using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DTO.Response
{
    public class GetPostsResponse
    {
        public IEnumerable<PostDto> BlogPosts { get; set; }
        public int PostsCount { get; set; }
    }
}
