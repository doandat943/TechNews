using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public CategoryController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/category/{id:int}")]
        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();

            var query = from menu in _context.Menu
                        where menu.MenuId == id && menu.IsActive
                        select menu;

            var what = query.ToList();

            var menuId = query.Select(x => x.MenuId).ToList();

            var posts = _context.Post
            .Where(post => menuId.Contains(post.MenuId))
            .ToList();

            ViewBag.Post = posts;

            if (what.Count == 0) return NotFound();

            return View(what);
        }
    }
}