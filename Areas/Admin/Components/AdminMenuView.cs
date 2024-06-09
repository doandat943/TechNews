using Microsoft.AspNetCore.Mvc;
using TechNews.Models;
using TechNews.Ultilities;

namespace TechNews.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminMenuView")]
    public class AdminMenuView : ViewComponent
    {
        private readonly DataContext _context;

        public AdminMenuView(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnList = (from m in _context.AdminMenu
                          where m.RoleId <= Functions._AccountRole
                          select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", mnList));
        }
    }
}