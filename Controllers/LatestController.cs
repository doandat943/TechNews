using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechNews.Models;

namespace TechNews.Controllers
{
    public class LatestController : Controller
    {
        private readonly ILogger<LatestController> _logger;

        private readonly DataContext _context;
        
        public LatestController(ILogger<LatestController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/latest")]
        public IActionResult Index()
        {
            var posts = (from post in _context.Post
                         join comment in _context.Comment on post.PostId equals comment.PostId into postComments
                         join menu in _context.Menu on post.MenuId equals menu.MenuId
                         join account in _context.Account on post.AuthorId equals account.AccountId
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
                             post.MenuId,
                             menu.MenuName,
                             CommentCount = postComments.Count(),
                             AuthorName = account.Name,
                             AuthorAvatar = account.Avatar
                         }).OrderByDescending(p => p.CreatedDate).ToList();

            ViewBag.Post = posts;

            return View();
        }
    }
}