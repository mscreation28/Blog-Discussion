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
using AutoMapper;
using BlogDiscussion2.ViewModels;

namespace BlogDiscussion2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger,
                                IMapper mapper,
                                ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BlogShortViewModel> blogs = _mapper.Map<IEnumerable<Blog>, IEnumerable< BlogShortViewModel >> (_context.blogs.Include(blog => blog.users));
            foreach(BlogShortViewModel bg in blogs)
            {
                Console.WriteLine("User Id: "+ bg.users.Id);
            }
            return View(await _context.blogs.ToListAsync());
        }

        [HttpPost]
        public IActionResult SetTheme(string data)
        {
            CookieOptions cookie = new CookieOptions();
            cookie.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append("Theme", data, cookie);
            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
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
        protected string Theme => Request.Cookies["Theme"] ?? "LIGHT";

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            ViewData["Theme"] = Theme;
            SetTheme(Theme);
            base.OnActionExecuted(context);
        }
    }
}
