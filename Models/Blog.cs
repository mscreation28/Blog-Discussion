using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BlogDiscussion2.Models
{
    public class Blog
    {

        [Key]
        public int id { get; set; }

        [ForeignKey("UserId")]
        public User users { get; set; }

        [Display(Name = "Title")]
        public string title { get; set; }

        [Display(Name = "Body")]
        [AllowHtml]
        public string body { get; set; }

        [Display(Name = "Category")]
        public string category { get; set; }

        [Display(Name = "Likes")]
        public int likes { get; set; } = 0;

        [Display(Name = "Replies")]
        public List<Reply> replies { get; set; }

        [Display(Name = "CreateDate")]
        public DateTime createdOn { get; set; } = DateTime.Now;

        [Display(Name = "Published")]
        public bool isPublished { get; set; } = false;
    }
}
