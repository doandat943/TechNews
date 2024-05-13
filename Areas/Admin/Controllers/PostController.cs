using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;
using TechNews.Models;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _context;

        public PostController(DataContext context){
            _context = context;
        }

        //[Route("/Admin/post-index(page:int).html", Name = "PostIndex")]
        public IActionResult Index(int page = 1)
        {
            var post = _context.Post.OrderByDescending(p => p.PostId);
            int pageSize = 10;
            PagedList<Post> models = new PagedList<Post>(post, 1, pageSize);
            if (models == null) return NotFound(); 
            return View(models);
        }

        public IActionResult Create() {
            var mnList = (from m in _context.Menu
            select new SelectListItem()
            {
                Text = m.MenuName,
                Value = m.MenuId.ToString()
            }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "--- Select ---",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post){
            if (ModelState.IsValid){
                _context.Post.Add(post);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}