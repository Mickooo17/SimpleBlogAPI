using SimpleBlog.DTO.Response;
using SimpleBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Repository.Contracts
{
    public interface ITagRepository
    {
        Task<GetTagsResponse> GetTags();
    }
}
