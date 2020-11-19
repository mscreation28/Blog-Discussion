using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogDiscussion2.Models;
using BlogDiscussion2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace BlogDiscussion2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,
                                ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.blogs.ToListAsync());
        }

        [HttpPost]
        public IActionResult SetTheme(string data)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Theme", "dark", cookie);
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> LikeBlog(Int32 id)
        {
            _logger.LogInformation(id.ToString());
            Blog blog =  _context.blogs.Find(id);
            _logger.LogInformation(blog.title);
            blog.likes++; // Increase like count
            _context.Update(blog);
            await _context.SaveChangesAsync();
            return Json(blog);
        }
        [HttpPost]
        public JsonResult timepass(Int32? id)
        {
            return Json(new { id = id });
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        protected string Theme => Request.Cookies["Theme"] ?? "light";

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewData["Theme"] = Theme;
            SetTheme(Theme);
            base.OnActionExecuted(context);
        }
    }
}
