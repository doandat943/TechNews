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
        return View();
    }

    public IActionResult Detail(int? id)
    {
        if (id == null) return NotFound();
        var post = _context.Post.FirstOrDefault(m => (m.PostId == id) && (m.IsActive == true));
        if (post == null) return NotFound();
        return View(post);
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
