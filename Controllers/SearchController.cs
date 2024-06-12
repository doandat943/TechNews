using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;

        private readonly DataContext _context;

        public SearchController(ILogger<SearchController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("/search")]
        public IActionResult Index(string keyword)
        {
            var posts = (from post in _context.Post
                         join comment in _context.Comment on post.PostId equals comment.PostId into postComments
                         join menu in _context.Menu on post.MenuId equals menu.MenuId
                         join account in _context.Account on post.AuthorId equals account.AccountId
                         where post.IsActive && (post.Title.Contains(keyword) || post.Summary.Contains(keyword) || post.Content.Contains(keyword))
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
                         }).OrderByDescending(p => p.View).ToList();
            ViewBag.PostCount = posts.Count();

            ViewBag.Post = posts;

            return View();
        }
    }
}