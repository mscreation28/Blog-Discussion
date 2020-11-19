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

        public DbSet<Blog> blogs { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Reply> replies { get; set; }
        public DbSet<Notification> notifications { get; set; }
    }
}
