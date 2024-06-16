using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;
using TechNews.Models;
using TechNews.Ultilities;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _context;

        public PostController(DataContext context)
        {
            _context = context;
        }

        [Route("/Admin/Post/Index", Name = "PostIndex")]
        public IActionResult Index(int page = 1)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            IQueryable<Post> post = _context.Post;
            if (Functions._AccountRole == 2)
            {
                post = post.Where(p => p.AuthorId == Functions._AccountId);
            }
            post = post.OrderByDescending(p => p.PostId);
            int pageSize = 10;
            PagedList<Post> models = new PagedList<Post>(post, page, pageSize);
            if (models == null) return NotFound();
            return View(models);
        }

        public IActionResult Create()
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            var menuList = (from m in _context.Menu
                            where m.Level == 2 &&
                                  m.MenuId == _context.Account
                                               .Where(p => p.AccountId == Functions._AccountId)
                                               .Select(p => p.MenuId)
                                               .FirstOrDefault()
                            select new SelectListItem
                            {
                                Text = m.MenuName,
                                Value = m.MenuId.ToString()
                            }).ToList();

            ViewBag.menuList = menuList;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedDate = DateTime.Now;
                post.MenuId = (int)_context.Account
                    .Where(p => p.AccountId == Functions._AccountId)
                    .Select(p => p.MenuId)
                    .FirstOrDefault();
                _context.Post.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public IActionResult Edit(int? id)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null || id == 0)
                return NotFound();
            var mn = _context.Post.Find(id);
            if (mn == null)
                return NotFound();

            var menuList = (from m in _context.Menu
                            where m.Level == 2
                            select new SelectListItem()
                            {
                                Text = m.MenuName,
                                Value = m.MenuId.ToString()
                            }).ToList();
            menuList.Insert(0, new SelectListItem()
            {
                Text = "--- Chọn ---",
                Value = string.Empty
            });
            ViewBag.menuList = menuList;
            return View(mn);
        }

        [HttpPost]
        public IActionResult Edit(Post mn)
        {
            if (ModelState.IsValid)
            {
                mn.CreatedDate = DateTime.Now;
                _context.Post.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }

        public IActionResult Delete(int? id)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _context.Post.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delPost = _context.Post.Find(id);
            if (delPost == null) return NotFound();
            _context.Post.Remove(delPost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}