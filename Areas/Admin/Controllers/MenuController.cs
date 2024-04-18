using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;

        public MenuController( DataContext context){
            _context = context;
        }

        public IActionResult Index(){
            var mnList = _context.Menus.OrderBy(m => m.MenuId).ToList ();
            return View(mnList);
        }
        public IActionResult Delete (int? id)
        {
            if (id == null || id ==0)
               return NotFound();
            var mn = _context.Menus.Find(id);
            if (mn == null)
               return NotFound();
            return View(mn);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delMenu = _context.Menus.Find(id);
            if (delMenu == null)
                return NotFound();
            _context.Menus.Remove(delMenu);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}