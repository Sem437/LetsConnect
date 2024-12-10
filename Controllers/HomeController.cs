using LetsConnect.Data;
using LetsConnect.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LetsConnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var workshops = from w in _context.WorkshopModel select w;

            return View(await workshops.ToListAsync());
        }

        // POST: Index
        // Studenten gekozen workshops
        [HttpPost]
        public async Task<IActionResult> GekozenWorkshop([Bind("Id", "UserId", "StudentNumber", "StundentWorkshop1", "StundentWorkshop2", "StundentWorkshop3")] WorkshopModel workshopModel)
        {
            if (workshopModel == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Add(workshopModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
