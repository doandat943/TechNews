using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

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
            int id = 1;
            var mn = _context.AboutUs.Find(id);
            if (mn == null)
                return NotFound();
            return View(mn);
        }

        [HttpPost]
        public IActionResult Edit(AboutUs mn)
        {
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