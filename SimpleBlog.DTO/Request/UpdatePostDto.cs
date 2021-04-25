using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DTO.Request
{
    public class UpdatePostDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}
