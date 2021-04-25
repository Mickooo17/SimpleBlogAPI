using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Entity
{
    public class PostTags
    {
        public Post Post { get; set; }
        [ForeignKey(nameof(Post))]
        public string Slug { get; set; }

        public Tag Tag { get; set; }
        [ForeignKey(nameof(Tag))]
        public string TagName { get; set; }
    }
}
