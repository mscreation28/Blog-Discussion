using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BlogDiscussion2.Models;

namespace BlogDiscussion2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Blog_Discussion_Db;Trusted_Connection=True;MultipleActiveResultSets=true");
        }        

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Reply> Replies { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}
