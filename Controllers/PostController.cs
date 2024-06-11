using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;
using TechNews.Ultilities;

namespace TechNews.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;

        private readonly DataContext _context;

        public PostController(ILogger<PostController> logger, DataContext context)
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
                        join comment in _context.Comment on post.PostId equals comment.PostId into postComments
                        where post.PostId == id
                        select new
                        {
                            post.PostId,
                            post.Title,
                            post.Summary,
                            post.Image,
                            post.CreatedDate,
                            post.AuthorId,
                            post.View,
                            post.Content,
                            menu.MenuName,
                            CommentCount = postComments.Count(),
                            AuthorName = account.Name,
                            AuthorAvatar = account.Avatar
                        };

            var what = query.ToList();

            var postIds = query.Select(x => x.PostId).ToList();

            var comments = _context.Comment
            .Where(comment => postIds.Contains(comment.PostId))
            .ToList();

            ViewBag.Comments = comments;

            // Bai viet

            var postList = _context.Post;
            ViewBag.Post = postList;

            if (what.Count == 0) return NotFound();

            // tang view
            var postToUpdate = _context.Post.FirstOrDefault(p => p.PostId == id);
            if (postToUpdate != null)
            {
                postToUpdate.View += 1;
                _context.SaveChanges();
            }

            return View(what);
        }

        [HttpPost]
        public ActionResult Comment(Comment comment)
        {
            if (comment == null) return NotFound();
            comment.CreatedDate = DateTime.Now;
            _context.Comment.Add(comment);
            _context.SaveChanges();
            return NoContent();
        }
    }
}