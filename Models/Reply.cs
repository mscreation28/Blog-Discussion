using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.Models
{
    public class Reply
    {
        [Key]
        public int ReplyId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        [Display(Name = "Blog ID")]
        public int BlogId { get; set; } 
        [ForeignKey("BlogId")]
        public Blog Blog { get; set; }

        [Display(Name = "Reply Content")]
        public string ReplyContent { get; set; }

        [Display(Name = "Reply Like Count")]
        public int ReplyLikeCount { get; set; }
    }
}
