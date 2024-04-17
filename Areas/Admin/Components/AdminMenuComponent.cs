using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private readonly DataContext _context;

        public AdminMenuComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnList = (from mn in _context.AdminMenus
                          where (mn.IsActive)
                          select mn).ToList();
            foreach (var item in mnList.ToArray())
            {
                Console.WriteLine($"AdminMenuId: {item.AdminMenuId}, ItemName: {item.ItemName}, ItemLevel: {item.ItemLevel}..."); // Hiển thị thông tin của mỗi AdminMenu
            }
            Console.WriteLine(mnList.ToArray());
            return await Task.FromResult((IViewComponentResult)View("Default", mnList));
        }
    }
}