using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;
using Microsoft.AspNetCore.Mvc;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private class readonly DataContext _context;
        public MenuController( DataContext context){
            _context = context;
        }
        public IActionResult Index(){
            var mnList = _context.Menus.OderBy(m => m.MenuID).ToList ();
            return View(mnList);
        }
        
    }
}