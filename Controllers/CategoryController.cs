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
        private readonly ILogger<CategoryController> _logger;

        private readonly DataContext _context;

        public CategoryController(ILogger<CategoryController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/category/{id:int}")]
        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();

            var posts = (from post in _context.Post
                         join comment in _context.Comment on post.PostId equals comment.PostId into postComments
                         join menu in _context.Menu on post.MenuId equals menu.MenuId
                         where post.MenuId == id && post.IsActive
                         select new
                         {
                             post.PostId,
                             post.Title,
                             post.Summary,
                             post.Image,
                             post.CreatedDate,
                             post.AuthorId,
                             post.View,
                             menu.MenuName,
                             CommentCount = postComments.Count()
                         }).OrderByDescending(p => p.CreatedDate).ToList();

            ViewBag.Post = posts;

            var query = from menu in _context.Menu
                        where menu.MenuId == id && menu.IsActive
                        select menu;

            var menus = query.ToList();

            return View(menus);
        }
    }
}