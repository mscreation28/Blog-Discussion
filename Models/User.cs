using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.Models
{
    public class User: IdentityUser
    {        
        [Display(Name = "Name")]
        public string uName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string userEmail { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string userPassword { get; set; }

        [Display(Name = "Profile Picture")]
        public string userProfilePicture { get; set; }

        [Display(Name = "Mobile Number")]        
        public string userMobileNum { get; set; }

        [Display(Name = "Twitter Handle")]
        public string userTwitterHandle { get; set; }

        [Display(Name = "Instagram Handle")]
        public string userInstagramHandle { get; set; }

        [Display(Name = "Facebook Handle")]
        public string userFacebookHandle { get; set; }
        
        public List<Blog> Blogs { get; set; }

        [Display(Name = "User Replies")]
        public List<Reply> UserReplies { get; set; }

        //[Display(Name = "User Liked Blogs")]
        //public List<Blog> UserLikedBlogs { get; set; }

        //[Display(Name = "User BookmarkedBlogs")]
        //public List<Blog> UserBookmarkedBlogs { get; set; }        
    }
}
