using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Controllers
{
    public class TrendingController : Controller
    {
        private readonly ILogger<TrendingController> _logger;

        private readonly DataContext _context;
        
        public TrendingController(ILogger<TrendingController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/trending")]
        public IActionResult Index()
        {
            var posts = (from post in _context.Post
                         join comment in _context.Comment on post.PostId equals comment.PostId into postComments
                         join menu in _context.Menu on post.MenuId equals menu.MenuId
                         where post.IsActive
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
                         }).OrderByDescending(p => p.View).ToList();

            ViewBag.Post = posts;

            return View();
        }
    }
}