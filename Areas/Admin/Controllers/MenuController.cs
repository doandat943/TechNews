using System.ComponentModel.Design;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using TechNews.Models;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _context;

        public MenuController(DataContext context){
            _context = context;
        }

        public IActionResult Index(){
            var mnList = _context.Menu.OrderBy(m => m.MenuId).ToList();
            return View(mnList);
        }

        public IActionResult Delete (int? id)
        {
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
            var mnList = ( from m in _context.Menu 
                           select new SelectListItem()
                           { 
                            Text = (m.Level == 1)? m.MenuName :"--"+ m.MenuName,
                            Value = m.MenuId.ToString()
                           }) .ToList();
            mnList.Insert (0, new SelectListItem()
            {
                Text = "--select--",
                Value = "0"
            });
            ViewBag.mnList = mnList;
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
            if (id == null|| id ==0)
               return NotFound();
            var mn = _context.Menu.Find(id);
            if ( mn == null)
               return NotFound();
            var mnList = ( from m in _context.Menu
                           select new SelectListItem()
                           {
                            Text = (m.Level == 1)? m.MenuName :"--"+ m.MenuName,
                            Value = m.MenuId.ToString()
                           }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text= "--select--",
                Value ="0"
            });
            ViewBag.mnList = mnList;
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