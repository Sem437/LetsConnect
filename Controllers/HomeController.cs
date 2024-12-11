using LetsConnect.Data;
using LetsConnect.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Security.Claims;

namespace LetsConnect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Student> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<Student> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            ViewBag.StudentNumber = 0;

            if (User.Identity.IsAuthenticated)
            {
                string UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var student = await _userManager.FindByIdAsync(UserId);

                ViewBag.StudentNumber = student.StudentNumber;
            }

            var workshops = from w in _context.WorkshopModel select w;

            return View(await workshops.ToListAsync());
        }

        // POST: Index
        // Studenten gekozen workshops
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdStudentWorkshop,StudentId,WorkshopId,WorkshopType")] WorkshopStudents studentWorkshop)
        {
            if (ModelState.IsValid)
            {                
                var student = await _context.Students.FirstOrDefaultAsync(s => s.Id == studentWorkshop.StudentId);

                if (student == null)
                {
                    // foutmelding als de student niet gevonden is
                    ModelState.AddModelError("", "Geen student gevonden met dit studentnummer.");
                    ViewData["WorkshopId"] = new SelectList(_context.WorkshopModel, "WorkshopId", "WorkshopDescription", studentWorkshop.WorkshopId);
                    return View(studentWorkshop);
                }

              
                studentWorkshop.StudentId = student.Id; // Gebruik de Id van AspNetUsers als StudentId

                // Voeg de nieuwe StudentWorkshop toe aan de database
                _context.Add(studentWorkshop);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            // Als er een fout is, herlaad de dropdown voor workshops
            ViewData["WorkshopId"] = new SelectList(_context.WorkshopModel, "WorkshopId", "WorkshopDescription", studentWorkshop.WorkshopId);
            return View(studentWorkshop);
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
