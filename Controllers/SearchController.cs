using System.Text.RegularExpressions;
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
                         where post.IsActive && (post.Title.Contains(keyword) || post.Summary.Contains(keyword))
                         select new
                         {
                             post.PostId,
                             post.Title,
                             post.Summary,
                             post.Content,
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

            var sortedPosts = posts.AsEnumerable()
                      .OrderByDescending(p => CountKeywordOccurrences(p.Title, keyword)*3 +
                                              CountKeywordOccurrences(p.Summary, keyword)*2 +
                                              CountKeywordOccurrences(p.Content, keyword)*1)
                      .ToList();

            ViewBag.PostCount = posts.Count();

            ViewBag.Post = sortedPosts;

            return View();
        }
        

        private int CountKeywordOccurrences(string input, string keyword)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(keyword))
                return 0;

            MatchCollection matches = Regex.Matches(input, keyword, RegexOptions.IgnoreCase);
            return matches.Count;
        }

    }
}