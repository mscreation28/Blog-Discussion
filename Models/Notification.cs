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
        public int NotificationId { get; set; }

        [Display(Name = "User ID")]
        public string UserId { get; set; }        
        public User User { get; set; }

        [Display(Name = "Label")]        
        public string NotificationLabel { get; set; }

        [Display(Name = "Content")]
        public string NotificationContent { get; set; }
    }
}
