using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagedList.Core;
using TechNews.Models;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _context;

        public PostController(DataContext context){
            _context = context;
        }

        [Route("Admin/post-index(page:int).html", Name = "PostIndex")]
        public IActionResult Index()
        {
            var post = _context.Post.OrderByDescending(p => p.PostId);
            int pageSize = 10;
            PagedList<Post> models = new PagedList<Post>(post, 1, pageSize);
            if (models == null) return NotFound(); 
            return View(models);
        }

    }
}