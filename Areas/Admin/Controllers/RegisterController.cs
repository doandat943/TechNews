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