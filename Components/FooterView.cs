using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Components
{
    [ViewComponent(Name = "FooterView")]
    public class FooterView : ViewComponent
    {
        private readonly DataContext _context;

        public FooterView(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var postList = (from post in _context.Post
                            join menu in _context.Menu on post.MenuId equals menu.MenuId
                            //where (m.IsActive == true)
                            select new
                            {
                                Post = post,
                                Menu = menu
                            }).ToList();

            var menus = _context.Menu
            .Where(i => i.ParentId == 2)
            .ToList();

            ViewBag.Menu = menus;

            return await Task.FromResult((IViewComponentResult)View("Default", postList));
        }
    }
}