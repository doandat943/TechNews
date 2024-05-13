using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminMenuView")]
    public class AdminMenuViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public AdminMenuViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnList = (from m in _context.AdminMenu
                          select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", mnList));
        }
    }
}