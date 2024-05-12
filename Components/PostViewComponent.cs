using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Components
{
    [ViewComponent(Name = "PostView")]
    public class PostViewComponent : ViewComponent
    {
        private readonly DataContext _context;

        public PostViewComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var postList = (from m in _context.Post
                          //where (m.IsActive == true)
                          select m).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", postList));
        }
    }
}