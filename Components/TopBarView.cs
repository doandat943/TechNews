using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Components
{
    [ViewComponent(Name = "TopBarView")]
    public class TopBarView : ViewComponent
    {
        private readonly DataContext _context;

        public TopBarView(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var aboutUs = _context.AboutUs.FirstOrDefault();
            ViewBag.AboutUs = aboutUs;

            return await Task.FromResult((IViewComponentResult)View("Default"));
        }
    }
}