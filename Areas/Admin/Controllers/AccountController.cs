using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PagedList.Core;
using TechNews.Models;
using TechNews.Ultilities;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController: Controller
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [Route("/Admin/Account/Index", Name = "AccountIndex")]
        public IActionResult Index(int page = 1)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            var post = _context.Account.OrderByDescending(p => p.AccountId);
            int pageSize = 10;
            PagedList<Account> models = new PagedList<Account>(post, page, pageSize);
            if (models == null) return NotFound();
            return View(models);
        }

        public IActionResult Create()
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            var genderList = (from m in _context.Gender
                          select new SelectListItem()
                          {
                              Text = m.GenderName,
                              Value = m.GenderId.ToString()
                          }).ToList();
            genderList.Insert(0, new SelectListItem()
            {
                Text = "--- Chọn ---",
                Value = string.Empty
            });

            var roleList = (from m in _context.Role
                          select new SelectListItem()
                          {
                              Text = m.RoleName,
                              Value = m.RoleId.ToString()
                          }).ToList();
            roleList.Insert(0, new SelectListItem()
            {
                Text = "--- Chọn ---",
                Value = string.Empty
            });

            ViewBag.genderList = genderList;
            ViewBag.roleList = roleList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Account post)
        {
            if (ModelState.IsValid)
            {
                _context.Account.Add(post);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        public IActionResult Delete(string? id)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null || id == null)
            {
                return NotFound();
            }
            var mn = _context.Account.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }
        
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delPost = _context.Account.Find(id);
            if (delPost == null) return NotFound();
            _context.Account.Remove(delPost);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(string? id)
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            if (id == null || id == null)
                return NotFound();
            var mn = _context.Account.Find(id);
            if (mn == null)
                return NotFound();

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

            var roleList = (from m in _context.Role
                          select new SelectListItem()
                          {
                              Text = m.RoleName,
                              Value = m.RoleId.ToString()
                          }).ToList();
            roleList.Insert(0, new SelectListItem()
            {
                Text = "--- Select ---",
                Value = string.Empty
            });

            ViewBag.genderList = genderList;
            ViewBag.roleList = roleList;
            return View(mn);
        }

        [HttpPost]
        public IActionResult Edit(Account mn)
        {
            if (ModelState.IsValid)
            {
                _context.Account.Update(mn);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
    }
}