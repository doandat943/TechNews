using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;
using TechNews.Ultilities;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutUsController : Controller
    {
        private readonly DataContext _context;

        public AboutUsController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Edit()
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            int id = 1;
            var mn = _context.AboutUs.Find(id);
            if (mn == null)
                return NotFound();
            return View(mn);
        }

        [HttpPost]
        public IActionResult Edit(AboutUs mn)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (ModelState.IsValid)
            {
                _context.AboutUs.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}