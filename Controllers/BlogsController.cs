﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BlogDiscussion2.Data;
using BlogDiscussion2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using BlogDiscussion2.ViewModels;

namespace BlogDiscussion2.Controllers
{
    public class BlogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public BlogsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.blogs.ToListAsync());
        }

        [Authorize]
        [HttpPost]
        public async Task<JsonResult> LikeBlog(Int32 id)
        {
            Blog blog = _context.blogs.Find(id);
            blog.likes++; // Increase like count
            _context.Update(blog);
            await _context.SaveChangesAsync();
            User user = await GetCurruntUserAsync();
            Notification noti = new Notification
            {
                user = user,
                label = "Like",
                body = user.UserName + " Liked Your Blog: " + blog.title
            };
            await _context.notifications.AddAsync(noti);
            await _context.SaveChangesAsync();
            return Json(blog);
        }
        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.blogs
                .FirstOrDefaultAsync(m => m.id == id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }
        public async Task<IActionResult> ViewBlog(Int32? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            Blog blog = await _context.blogs
                .Include(blog => blog.users)
                .FirstOrDefaultAsync(blog => blog.id == id);
            if(blog == null)
            {
                return NotFound();
            }
            BlogViewModel blogViewModel = new BlogViewModel
            {
                id = blog.id,
                title = blog.title,
                body = blog.body,
                category = blog.category,
                createdOn = blog.createdOn,
                likes = blog.likes,
                users = blog.users
            };
            return View(blogViewModel);
        }
        // GET: Blogs/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,title,body,category,likes,createdOn,isPublished")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.users = await GetCurruntUserAsync();
                blog.isPublished = true;
                _context.Add(blog);
                Console.WriteLine(blog.users.Id);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,body,category,likes,createdOn,isPublished")] Blog blog)
        {
            if (id != blog.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blog);
        }

        // GET: Blogs/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.blogs
                .FirstOrDefaultAsync(m => m.id == id);
            if (blog == null)
            {
                return NotFound();
            }

            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blog = await _context.blogs.FindAsync(id);
            _context.blogs.Remove(blog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogExists(int id)
        {
            return _context.blogs.Any(e => e.id == id);
        }

        private Task<User> GetCurruntUserAsync() => _userManager.GetUserAsync(HttpContext.User);
    }
}
