using BlogDiscussion2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.ViewModels
{
    public class BlogShortViewModel
    {
        public int id { get; set; }
        public User user { get; set; }
        public string  title { get; set; }
        public string body { get; set; }
        public string category { get; set; }
        public int likes { get; set; }
        public DateTime createdOn { get; set; }
    }
}
