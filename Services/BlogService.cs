using BlogDiscussion2.Data;
using BlogDiscussion2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.Services
{
    public class BlogService : IBlogRepository
    {
        private readonly ApplicationDbContext _context;        
        private readonly UserManager<User> _userManager;
        public BlogService(ApplicationDbContext context, UserManager<User> userManager)
        {
            this._context = context;
            _context.Database.EnsureCreated();
            _userManager = userManager; 
        }
        public Blog DeleteBlog(Int32 id)
        {
            Blog blog = _context.blogs.FirstOrDefault(blog => blog.id == id);
            if(null == blog)
            {
                _context.blogs.Remove(blog);
                _context.SaveChanges();
            }
            return blog;
        }

        public Blog GetBlogById(Int32 id)
        {
            return _context.blogs.FirstOrDefault(blog => blog.id == id);
        }

        public IEnumerable<Blog> GetBlogs()
        {
            return _context.blogs;
        }
       
    }
}
