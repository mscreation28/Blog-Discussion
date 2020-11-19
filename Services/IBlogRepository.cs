using BlogDiscussion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.Services
{
    public interface IBlogRepository
    {
        IEnumerable<Blog> GetBlogs();

        Blog GetBlogById(Int32 id);

        Blog DeleteBlog(Int32 id);
    }
}
