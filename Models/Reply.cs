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
        public int id { get; set; }

        [ForeignKey("UserId")]
        public User user { get; set; }

        [ForeignKey("BlogId")]
        public Blog blog { get; set; }

        [Display(Name = "Body")]
        public string body { get; set; }

        [Display(Name = "Like Count")]
        public int likes { get; set; } = 0;
    }
}
