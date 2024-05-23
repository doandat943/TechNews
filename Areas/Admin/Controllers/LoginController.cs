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
    public class LoginController : Controller
    {
        private readonly DataContext _context;
        public LoginController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Account account)
        {
            if (account == null) return NotFound();
            //Convert password to MD5
            Console.WriteLine(account.AccountId);
            Console.WriteLine(account.Password);
            string pw = Functions.MD5Password(account.Password);
            //Check the information in database
            var check = _context.Account.Where(u => (u.AccountId == account.AccountId) && (u.Password == pw)).FirstOrDefault();
            if (check == null)
            {
                Functions._Message = "Invalid username and password!";
                return RedirectToAction("Index", "Login");
            }

            var roleName = _context.Role
                                  .Where(u => u.RoleId == check.RoleId)
                                  .Select(u => u.RoleName)
                                  .FirstOrDefault();

            Functions._Message = string.Empty;
            Functions._AccountId = check.AccountId;
            Functions._AccountName = string.IsNullOrEmpty(check.Name) ? string.Empty : check.Name;
            Functions._AccountType = roleName;
            return RedirectToAction("Index", "Home");
        }
    }
}