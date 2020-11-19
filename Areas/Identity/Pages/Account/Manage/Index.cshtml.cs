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
using Microsoft.AspNetCore.Http;

namespace BlogDiscussion2.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        
        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public string Username { get; set; }
        
        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Email")]
            public string Email { get; set; }

            [Display(Name = "Twitter")]
            public string userTwitterHandle { get; set; }

            [Display(Name = "Instagram")]
            public string userInstagramHandle { get; set; }

            [Display(Name = "Facebook")]
            public string userFacebookHandle { get; set; }
            public string theme { get; set; }

        }


        private async Task LoadAsync(User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);            
            var user_data = (User)await _userManager.FindByIdAsync(user.Id);            

            Username = userName;

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                userTwitterHandle = user_data.userTwitterHandle,
                userInstagramHandle = user_data.userInstagramHandle,
                userFacebookHandle = user_data.userFacebookHandle,
                theme = Request.Cookies["Theme"]
            };
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

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            //var twitterHandle = User.Identity.GetUserTHandle();
            var user_data = (User)await _userManager.FindByIdAsync(user.Id);
            user_data.userTwitterHandle = Input.userTwitterHandle;
            user_data.userFacebookHandle = Input.userFacebookHandle;
            user_data.userInstagramHandle = Input.userInstagramHandle;

            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Theme", Input.theme, cookie);            

            user_data.userTwitterHandle = Input.userTwitterHandle;
            await _userManager.UpdateAsync(user_data); 

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
