using SimpleBlog.DTO.Request;
using SimpleBlog.Entity.Context;
using SimpleBlog.Entity.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Entity.Seeder
{
    public class DbSeeder
    {
        public static void Initialize(SimpleBlogDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any tags.
            if (context.Tags.Any())
            {
                return;   // DB has been seeded
            }

            var tags = new Tag[]
            {
                new Tag { TagName = "iOS"},
                new Tag { TagName = "AR"},
                new Tag { TagName = "Gazzda"},
            };

            foreach (Tag t in tags)
            {
                context.Tags.Add(t);
            }
            context.SaveChanges();

            var posts = new Post[]
            {
                new Post
                {
                    Title = "Augmented Reality iOS Application",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit."
                },
                new Post
                {
                    Title = "Augmented Reality iOS Application 2",
                    Description = "Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.",
                    Body = "The app is simple to use, and will help you decide on your best furniture fit."
                }
            };

            posts[0].TagList.Add(new PostTags { Tag = tags[0] });
            posts[0].TagList.Add(new PostTags { Tag = tags[1] });

            posts[1].TagList.Add(new PostTags { Tag = tags[0] });
            posts[1].TagList.Add(new PostTags { Tag = tags[1] });
            posts[1].TagList.Add(new PostTags { Tag = tags[2] });
  
            foreach (Post p in posts)
            {
                p.Slug = p.Title.GetSlug();
                p.CreatedAt = p.UpdatedAt = DateTime.Now;

                context.Posts.Add(p);
            }
            context.SaveChanges();
        }
    }
}
