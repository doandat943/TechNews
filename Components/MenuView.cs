using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuView : ViewComponent
    {
        private readonly DataContext _context;

        public MenuView(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var menuList = (from m in _context.Menu
                          where (m.IsActive == true)
                          select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", menuList));
        }
    }
}