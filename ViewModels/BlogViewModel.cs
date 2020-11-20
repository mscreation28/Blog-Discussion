using BlogDiscussion2.Models;
using System;

namespace BlogDiscussion2.ViewModels
{
    public class BlogViewModel
    {
        public int id { get; set; }
        public User users { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string category { get; set; }
        public int likes { get; set; }
        public DateTime createdOn { get; set; }
    }
}
