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
    public class PostRepository : IPostRepository
    {
        private readonly SimpleBlogDbContext _context;

        public PostRepository(SimpleBlogDbContext SimpleBlogDbContext)
        {
            this._context = SimpleBlogDbContext;
        }

        public GetPostsResponse GetPosts(GetPostsRequest request)
        {
            var response = new GetPostsResponse
            {
                BlogPosts = _context.Posts.Select(
                    x => new PostDto
                    {
                        Body = x.Body,
                        CreatedAt = x.CreatedAt,
                        Description = x.Description,
                        Slug = x.Slug,
                        Title = x.Title,
                        UpdatedAt = x.UpdatedAt,
                        TagList = x.TagList.Select(y => y.TagName)
                    }
                )
                .Where(x => request.Tag == null || x.TagList.Any(y => y == request.Tag))
                .OrderByDescending(x => x.UpdatedAt)
                .ToList()
            };

            response.PostsCount = response.BlogPosts.Count();

            return response;
        }

        public GetPostResponse GetPost(string slug)
        {
            return new GetPostResponse
            {
                BlogPost = _context.Posts
                    .Where(e => e.Slug == slug)
                    .Select(x => new PostDto
                    {
                        Body = x.Body,
                        CreatedAt = x.CreatedAt,
                        Description = x.Description,
                        Slug = x.Slug,
                        Title = x.Title,
                        UpdatedAt = x.UpdatedAt,
                        TagList = x.TagList.Select(y => y.TagName)
                    })
                    .FirstOrDefault()
            };
        }

        public GetPostResponse CreatePost(CreatePostRequest dto)
        {
            if (_context.Posts.Find(dto.BlogPost.Title.GetSlug()) != null)
                throw new UserException("A post with the same slug already exists.");

            var entity = new Post
            {
                Title = dto.BlogPost.Title,
                Description = dto.BlogPost.Description,
                Body = dto.BlogPost.Body,
                Slug = dto.BlogPost.Title.GetSlug(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            foreach (string tagName in dto.BlogPost.TagList)
            {
                var tag = _context.Tags.Find(tagName);
                if (tag != null)
                {
                    entity.TagList.Add(new PostTags { Tag = tag });
                }
                else
                {
                    throw new UserException("Tag " + tagName + " is not valid.");
                }
            }

            _context.Posts.Add(entity);
            _context.SaveChanges();
            return  GetPost(entity.Slug);
        }

        public GetPostResponse UpdatePost(string slug, UpdatePostRequest dto)
        {
            var entity = _context.Posts
                .Include(x => x.TagList)
                .FirstOrDefault(e => e.Slug == slug);

            if (entity != null)
            {
                if (!string.IsNullOrEmpty(dto.BlogPost.Title))
                {
                    _context.Posts.Remove(entity);
                     _context.SaveChanges();

                    entity = new Post
                    {
                        Title = dto.BlogPost.Title,
                        Body = entity.Body,
                        CreatedAt = entity.CreatedAt,
                        Description = entity.Description,
                        Slug = dto.BlogPost.Title.GetSlug(),
                        TagList = entity.TagList
                    };
                    _context.Posts.Add(entity);
                }

                if (!string.IsNullOrEmpty(dto.BlogPost.Description))
                {
                    entity.Description = dto.BlogPost.Description;
                }
                if (!string.IsNullOrEmpty(dto.BlogPost.Body))
                {
                    entity.Body = dto.BlogPost.Body;
                }

                entity.UpdatedAt = DateTime.Now;

                _context.SaveChanges();

                return GetPost(entity.Slug);
            }

            return null;
        }

        public bool DeletePost(string slug)
        {
            var result = _context.Posts
                .FirstOrDefault(e => e.Slug == slug);
            if (result != null)
            {
                _context.Posts.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
