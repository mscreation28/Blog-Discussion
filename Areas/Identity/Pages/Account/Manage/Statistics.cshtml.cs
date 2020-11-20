using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlogDiscussion2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BlogDiscussion2.Data;

namespace BlogDiscussion2.Areas.Identity.Pages.Account.Manage
{
    public partial class Statistics : PageModel
    {
        private UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        
        public Statistics(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }

        public int blogcount { get; set; }      
        public int likecount { get; set; }
        public int replycount { get; set; }        
        
        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);            
            var user_data = (User)await _userManager.FindByIdAsync(user.Id);

            var temp_blogs = _context.blogs.AsEnumerable<Blog>();
            int cnt = _context.blogs.Count<Blog>(b => b.users.Id == user.Id);
            blogcount = cnt;

            var blogs_list = _context.blogs.Where(b => b.users.Id == user.Id);
            likecount = 0;
            foreach(var blog in blogs_list)
            {
                likecount += (Int32)blog.likes;
            }

            replycount = 0;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }
    }
}
