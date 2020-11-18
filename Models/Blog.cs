using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.Models
{
    public class Blog
    {
        [Key]
        public int BlogId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User Users { get; set; }

        [Display(Name = "Title")]
        public string BlogTitle { get; set; }

        [Display(Name = "Content")]
        [DataType(DataType.MultilineText)]
        public string BlogContent { get; set; }

        [Display(Name = "Category")]
        public string BlogCategory { get; set; }

        [Display(Name = "Like Count")]
        public int BlogLikeCount { get; set; }

        [Display(Name = "Replies")]
        public List<Reply> BlogReplies { get; set; }                

        [Display(Name = "CreateDate")]
        public DateTime BlogCreateDate { get; set; }

        [Display(Name = "Published")]
        public bool BlogPublished { get; set; }
    }
}
