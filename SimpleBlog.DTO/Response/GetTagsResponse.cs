using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DTO.Response
{
    public class GetTagsResponse
    {
        public IEnumerable<string> Tags { get; set; }
    }
}
