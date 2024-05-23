using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _context;
        public PostController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/post/{slug}-{id:int}")]
        public IActionResult Index(int? id)
        {
            if (id == null) return NotFound();

            var query = from post in _context.Post
                        join menu in _context.Menu on post.MenuId equals menu.MenuId
                        join account in _context.Account on post.AuthorId equals account.AccountId
                        where post.PostId == id && post.IsActive
                        select new
                        {
                            Post = post,
                            MenuName = menu.MenuName,
                            AccountName = account.Name,
                            AccountAvatar = account.Avatar
                        };

            var what = query.ToList();

            var postIds = query.Select(x => x.Post.PostId).ToList();

            var comments = _context.Comment
            .Where(comment => postIds.Contains(comment.PostId))
            .ToList();

            ViewBag.Comments = comments;

            if (what.Count == 0) return NotFound();

            return View(what);
        }

        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            if (comment == null) return NotFound();
            
            _context.Comment.Add(comment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}