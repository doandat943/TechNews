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
}
