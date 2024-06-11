using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechNews.Models;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
  
    public class AboutUsController : Controller 
    {
          private readonly DataContext _context;
          public AboutUsController(DataContext context){
            _context = context;
          }
          public IActionResult Edit()
          {
            int id = 1;
            var mn = _context.AboutUs.Find(id);
            if(mn == null)
               return NotFound();
            return View(mn);
          }
          [HttpPost]
          public IActionResult Edit(AboutUs mn)
          {
           if (ModelState.IsValid)
            {
                var existingMn = _context.AboutUs.Find(1);
                if (existingMn == null)
                {
                    return NotFound();
                }

                existingMn.AdminName = mn.AdminName;
                existingMn.Content = mn.Content;

                _context.AboutUs.Update(existingMn);
                _context.SaveChanges();
                return RedirectToAction("Edit"); // Chuyển hướng lại trang Edit
            }
            return View(mn);
          }
    }
}