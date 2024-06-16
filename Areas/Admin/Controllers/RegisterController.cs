using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TechNews.Models;
using TechNews.Ultilities;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RegisterController : Controller
    {
        private readonly DataContext _context;

        public RegisterController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (Functions.IsLogin())
            {
                return RedirectToAction("Index", "Home");
            }
            var genderList = (from m in _context.Gender
                          select new SelectListItem()
                          {
                              Text = m.GenderName,
                              Value = m.GenderId.ToString()
                          }).ToList();
            genderList.Insert(0, new SelectListItem()
            {
                Text = "--- Select ---",
                Value = string.Empty
            });
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
            ViewBag.genderList = genderList;
            return View();
        }
        
        [HttpPost]
        public ActionResult Index(Account account)
        {
            if (account == null) return NotFound();
            //Check the dublicate username before registering 
            var check = _context.Account.Where(u => (u.Name == account.Name)).FirstOrDefault();
            if (check != null) //Already exists this username
            {
                Functions._Message = "Username already exist";
                return RedirectToAction("Index", "Register");
            }
            //If username does not exist
            Functions._Message = string.Empty;
            account.Password = Functions.MD5Password(account.Password);
            _context.Account.Add(account);
            _context.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}