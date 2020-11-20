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
    public partial class NotificationModel : PageModel
    {
        private UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<User> _signInManager;
        
        public NotificationModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;

        }
        
        public IEnumerable<Notification> notifications_list { get; set; }
        
        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);            
            var user_data = (User)await _userManager.FindByIdAsync(user.Id);

            //var temp_blogs = _context.blogs.AsEnumerable<Blog>();
            //int cnt = _context.blogs.Count<Blog>(b => b.users.Id == user.Id);

            notifications_list = (IEnumerable<Notification>)_context.notifications.Where(b => b.user.Id == user.Id);

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

        //public async Task<IActionResult> OnPostAsync()
        //{
        //    var user = await _userManager.GetUserAsync(User);
        //    if (user == null)
        //    {
        //        return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        //    }

        //    if (!ModelState.IsValid)
        //    {
        //        await LoadAsync(user);
        //        return Page();
        //    }

        //    var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
        //    if (Input.PhoneNumber != phoneNumber)
        //    {
        //        var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
        //        if (!setPhoneResult.Succeeded)
        //        {
        //            StatusMessage = "Unexpected error when trying to set phone number.";
        //            return RedirectToPage();
        //        }
        //    }

        //    //var twitterHandle = User.Identity.GetUserTHandle();
        //    var user_data = (User)await _userManager.FindByIdAsync(user.Id);
        //    user_data.userTwitterHandle = Input.userTwitterHandle;
        //    user_data.userFacebookHandle = Input.userFacebookHandle;
        //    user_data.userInstagramHandle = Input.userInstagramHandle;

        //    user_data.userTwitterHandle = Input.userTwitterHandle;
        //    await _userManager.UpdateAsync(user_data); 

        //    await _signInManager.RefreshSignInAsync(user);
        //    StatusMessage = "Your profile has been updated";
        //    return RedirectToPage();
        //}
    }
}
