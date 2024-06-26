using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Components
{
    [ViewComponent(Name = "PostDetailView")]
    public class PostDetailView : ViewComponent
    {
        private readonly DataContext _context;

        public PostDetailView(DataContext context)
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
            return await Task.FromResult((IViewComponentResult)View("Default", postList));
        }
    }
}