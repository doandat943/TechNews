using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DataContext _context;
    public HomeController(ILogger<HomeController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var postList = (from post in _context.Post
                        join menu in _context.Menu on post.MenuId equals menu.MenuId
                        //where (m.IsActive == true)
                        select new
                        {
                            Post = post,
                            Menu = menu
                        }).ToList();
        return View(postList);
    }

    [Route("/category/{id:int}")]
    public IActionResult Category(int? id)
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


    [Route("/post/{slug}-{id:int}")]
    public IActionResult Detail(int? id)
    {
        if (id == null) return NotFound();

        var query = from post in _context.Post
                    join menu in _context.Menu on post.MenuId equals menu.MenuId
                    join account in _context.Account on post.AuthorId equals account.AccountId
                    where post.PostId == id && post.IsActive
                    select new
                    {
                        Post = post,
                        MenuNamee = menu.MenuName,
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

    public IActionResult Privacy()
    {
        return View();
    }
}
