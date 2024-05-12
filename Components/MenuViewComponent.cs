using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public MenuViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuList = (from m in _context.Menu
                          where (m.IsActive == true) && (m.Area == 1)
                          select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", menuList));
        }
    }
}