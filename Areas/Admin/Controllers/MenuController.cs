using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;
using TechNews.Models;
using TechNews.Ultilities;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;

        public MenuController(DataContext context){
            _context = context;
        }

        public IActionResult Index(int page = 1){
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            IQueryable<Menu> post = _context.Menu;
            int pageSize = 10;
            PagedList<Menu> models = new PagedList<Menu>(post, page, pageSize);
            if (models == null) return NotFound();
            return View(models);
        }

        public IActionResult Delete (int? id)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null || id ==0)
               return NotFound();
            var mn = _context.Menu.Find(id);
            if (mn == null)
               return NotFound();
            return View(mn);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delMenu = _context.Menu.Find(id);
            if (delMenu == null)
                return NotFound();
            _context.Menu.Remove(delMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            var menuList = ( from m in _context.Menu 
                           select new SelectListItem()
                           { 
                            Text = (m.Level == 1)? m.MenuName :"-- "+ m.MenuName,
                            Value = m.MenuId.ToString()
                           }) .ToList();
            menuList.Insert (0, new SelectListItem()
            {
                Text = "-- Chọn --",
                Value = "0"
            });
            ViewBag.menuList = menuList;
            return View();                 
        }

        [HttpPost]
        public IActionResult Create(Menu mn)
        {
            if ( ModelState.IsValid)
            {
                _context.Menu.Add(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }

        public IActionResult Edit(int? id)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null|| id ==0)
               return NotFound();
            var mn = _context.Menu.Find(id);
            if ( mn == null)
               return NotFound();

            var menuList = (from m in _context.Menu
                           select new SelectListItem()
                           {
                            Text = (m.Level == 1)? m.MenuName : "--"+ m.MenuName,
                            Value = m.MenuId.ToString()
                           }).ToList();
            menuList.Insert(0, new SelectListItem()
            {
                Text= "--select--",
                Value ="0"
            });
            ViewBag.menuList = menuList;
            return View(mn);   
        }
        
        [HttpPost]
        public IActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _context.Menu.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}