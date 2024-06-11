using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechNews.Models;

namespace TechNews.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ILogger<AboutUsController> _logger;

        private readonly DataContext _context;

        public AboutUsController(ILogger<AboutUsController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Route("/about-us")]
        public IActionResult Index()
        {
            var aboutUs = _context.AboutUs.FirstOrDefault();

            if (aboutUs == null)
            {
                return NotFound();
            }

            return View(aboutUs);
        }
    }
}