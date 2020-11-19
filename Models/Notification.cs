using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.Models
{
    public class Notification
    {
        [Key]
        public int id { get; set; }

        [Display(Name = "User ID")]
        public User user { get; set; }

        [Display(Name = "Label")]
        public string label { get; set; }

        [Display(Name = "Body")]
        public string body { get; set; }
    }
}
