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
                            where (post.IsActive)
                            orderby post.CreatedDate descending
                            select new
                            {
                                Post = post,
                                Menu = menu
                            }).Take(3).ToList();

            var menus = _context.Menu
            .Where(i => i.ParentId == 2)
            .ToList();

            ViewBag.Menu = menus;

            var aboutUs = _context.AboutUs.FirstOrDefault();
            ViewBag.AboutUs = aboutUs;

            return await Task.FromResult((IViewComponentResult)View("Default", postList));
        }
    }
}