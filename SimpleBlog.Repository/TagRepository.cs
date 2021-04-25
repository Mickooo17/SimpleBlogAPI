using Microsoft.EntityFrameworkCore;
using SimpleBlog.DTO.Request;
using SimpleBlog.DTO.Response;
using SimpleBlog.Entity;
using SimpleBlog.Entity.Context;
using SimpleBlog.Entity.Helper;
using SimpleBlog.Exceptions;
using SimpleBlog.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleBlog.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly SimpleBlogDbContext _context;

        public TagRepository(SimpleBlogDbContext SimpleBlogDbContext)
        {
            this._context = SimpleBlogDbContext;
        }

        public async Task<GetTagsResponse> GetTags()
        {
            return new GetTagsResponse
            {
                Tags = await _context.Tags.Select(
                    x => x.TagName
                ).ToListAsync()
            };
        }

    }
}
