using Microsoft.AspNetCore.Mvc;
using TechNews.Models;
using TechNews.Ultilities;

namespace TechNews.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly DataContext _context;

        public HomeController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!Functions.IsLogin())
            {
                return RedirectToAction("Index", "Login");
            }
            int todayView = _context.Analyst.FirstOrDefault(p => p.Date == DateTime.Today)?.View ?? 0;
            DateTime firstDayOfMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            int monthView = _context.Analyst.Where(p => p.Date >= firstDayOfMonth && p.Date <= DateTime.Today).Sum(p => p.View);
            int totalView = _context.Post.Sum(p => p.View);

            ViewBag.TodayView = todayView;
            ViewBag.MonthView = monthView;
            ViewBag.TotalView = totalView;

            var monthAnalyst = _context.Analyst.Where(p => p.Date >= firstDayOfMonth && p.Date <= DateTime.Today).ToList();
            ViewBag.MonthAnalyst = monthAnalyst;

            return View();
        }

        public IActionResult Logout()
        {
            Functions._AccountId = String.Empty;
            Functions._AccountName = String.Empty;
            Functions._AccountType = String.Empty;
            Functions._Message = String.Empty;
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}